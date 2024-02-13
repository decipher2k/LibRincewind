﻿/*
Copyright 2023 Dennis Michael Heine

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LibRincewind_4._7._2
{
  public class CRincewind
  {
    private IPlugin plugin;
    public byte[] IV;

    public CRincewind(string _plugin, int ivSize = 512)
    {
      foreach (Type exportedType in Assembly.LoadFile(_plugin).GetExportedTypes())
      {
        if (((IEnumerable<Type>) exportedType.GetInterfaces()).Contains<Type>(typeof (IPlugin)))
          this.plugin = (IPlugin) Activator.CreateInstance(exportedType);
      }
      this.IV = this.plugin.generateIV(ivSize);
    }

    public CCryptData encryptCCD(string toEncrypt, string password1, string password2)
    {
      byte[] randomKey = this.generateRandomKey(toEncrypt);
      byte[] bytes = Encoding.ASCII.GetBytes(toEncrypt.ToCharArray());
      for (int index = 0; index < randomKey.Length; ++index)
      {
        do
        {
          bytes[index] = this.rotateByLeft(bytes[index], (int) randomKey[index]);
        }
        while (bytes[index] < (byte) 36 || bytes[index] > (byte) 126);
      }
      byte[] inArray1 = this.plugin.encrypt(bytes, password1, this.IV);
      byte[] inArray2 = this.plugin.encrypt(randomKey, password2, this.IV);
      return new CCryptData()
      {
        CryptedData = Convert.ToBase64String(inArray1),
        Key = Convert.ToBase64String(inArray2),
        IV = this.IV
      };
    }

    public string encryptString(string toEncrypt, string password1, string password2)
    {
      CCryptData graph = this.encryptCCD(toEncrypt, password1, password2);
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      MemoryStream serializationStream = new MemoryStream();
      binaryFormatter.Serialize((Stream) serializationStream, (object) graph);
      return Convert.ToBase64String(serializationStream.GetBuffer());
    }

    public string decryptCCD(CCryptData cryptData, string password1, string password2)
    {
      byte[] data1 = Convert.FromBase64String(cryptData.CryptedData);
      byte[] data2 = Convert.FromBase64String(cryptData.Key);
      byte[] numArray1 = this.plugin.decrypt(data1, password1, cryptData.IV);
      byte[] numArray2 = this.plugin.decrypt(data2, password2, cryptData.IV);
      byte[] numArray3 = numArray1;
      char[] chArray = new char[numArray3.Length];
      for (int index = 0; index < numArray2.Length; ++index)
      {
        int num = 0;
        do
        {
          numArray3[index] = this.rotateByRight(numArray3[index], (int) numArray2[index]);
          ++num;
        }
        while ((numArray3[index] < (byte) 36 || numArray3[index] > (byte) 126) && numArray3[index] > (byte) 0);
        chArray[index] = (char) numArray3[index];
      }
      return new string(chArray);
    }

    public string decryptString(string cryptDataB64, string password1, string password2)
    {
      return this.decryptCCD((CCryptData) new BinaryFormatter().Deserialize((Stream) new MemoryStream(Convert.FromBase64String(cryptDataB64))), password1, password2);
    }

    private byte[] generateRandomKey(string input)
    {
      byte[] randomKey = new byte[input.Length];
      for (int index = 0; index < input.Length; ++index)
      {
        char ch = (char) new Random().Next(1, (int) byte.MaxValue);
        randomKey[index] = (byte) ch;
      }
      return randomKey;
    }

    private byte rotateByLeft(byte input, int delta)
    {
      delta %= 6;
      ++delta;
      byte num1 = input;
      for (int index = 0; index < delta; ++index)
      {
        byte num2 = (byte) ((uint) (byte) ((uint) num1 & 64U) >> 6);
        num1 = (byte) ((uint) (byte) ((uint) (byte) ((uint) num1 & 63U) << 1) | (uint) num2);
      }
      return num1;
    }

    private byte rotateByRight(byte input, int delta)
    {
      delta %= 6;
      ++delta;
      byte num1 = input;
      for (int index = 0; index < delta; ++index)
      {
        byte num2 = (byte) ((uint) (byte) ((uint) num1 & 1U) << 6);
        num1 = (byte) ((uint) (byte) ((uint) (byte) ((uint) num1 & 126U) >> 1) | (uint) num2);
      }
      return num1;
    }
  }
}
