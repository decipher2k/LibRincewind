# LibRincewind

A bruteforce protected aproach for encryption of plain text ASCII passwords.<br>
<br>
What is it about?<br>
<br>
Normal encryption of plain text passwords can theoretically be cracked because decryption attempts with a failure password will result in non-ASCII data.<br>
<br>
LibRincewind combines any symmetrical algorithm with a rotational algorithm so that false tries can't be distinguished from valid ones.<br>
<br>
How does it work?<br>
<br>
1.) The plain text gets encrypted using a password<br>
2.) The encrypted result is rotated using a random key for each character until it is valid ASCII<br>
3.) The key gets encrypted with another password<br>
<br>
Caveats:<br>
<br>
-The length of the plain text can be guessed, because it equals the length of the encryption/decryption key<br>
-The algorithm is still prone to wordlist attacks<br>
-The Demo is using Blowfish as the base algorithm, which is vulnerable to attacks using quantum computers. Yet the library is independend of the base algorithm, thus Blowfish can easily be replaced with AES or RC6 by creating a custom Plugin.<br>
-The Demo is using the DotNet Pseudo-RNG. Replace it with a QRNG in real world applications.<br>
<br>
Usage:<br>
<br>
CRincewind rw=new CRincewind("pluginlibrary.dll", 512);<br>
String enc=rw.encryptString("data","password1","password2");<br>
String dec=rw.decryptString(enc,"password1","password2");<br>
<br>
Creating custom plugins:<br>
<br>
Implement the interface found in LibRincewindPlugin.<br>
<br>
ToDo:<br>
IV's for each character

