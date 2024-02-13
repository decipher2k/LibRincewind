# LibRincewind

A post-quantum cryptographic, bruteforce protected aproach for encryption of plain text ASCII passwords.<br>
<br>
Synopsis:<br>
<br>
Normal encryption of plain text passwords can theoretically be broken by quantum computers in the future. This is due to the fact that decryption attempts with a failure password will result in non-ASCII data. Furthermore, any algorithm that produces non-ASCII output when using a failure password can be cracked by comparing the output to the ASCII table. <br><br>
<br>
LibRincewind simply combines a symetrical alogrithm with a rotational algorithm.<br>
<br>
A key used for decryption is being generated which contains the rotation delta for each character. This key gets encrypted with another password.
<br>
<br>
How does it work?<br>
<br>
1.) The plain text gets encrypted using a password<br>
2.) The encrypted result is rotated using a random key for each character until it is valid ASCII<br>
3.) If the result is invalid, it is rotated more until valid.<br>
4.) The key gets encrypted with another password<br>
<br>
Caveats:<br>
-The length of the plain text can be guessed, because it equals the length of the decryption key<br>
-The algorithm is still prone to wordlist attacks<br>
<br>
Usage:<br>
<br>
CRincewind rw=new CRincewind("pluginlibrary.dll", 512);<br>
String enc=rw.encryptString("data","password1","password2");<br>
String dec=rw.decryptString(enc,"password1","password2");<br>
<br>
Creating custom plugins:<br>
Derive from the interface found in LibRincewindPlugin.
