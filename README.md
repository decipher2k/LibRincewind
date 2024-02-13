# LibRincewind

A post-quantum cryptographic, bruteforce protected aproach for encryption of plain text ASCII passwords.<br>
<br>
Synopsis:<br>
<br>
Normal encryption of plain text passwords can theoretically be broken by quantum computers in the future. This is due to the fact that decryption attempts with a failure password will result in non-ASCII data. Furthermore, any algorithm that produces non-ASCII output when using a failure password can be cracked by comparing the output to the ASCII table. <br><br>
<br>
LibRincewind simply combines a symetrical alogrithm with a rotational algorithm.<br>
<br>
A key used for decryption is being generated which contains the rotation delta for each character. This key gets encrypted, too.
Thus, two passwords will be used for encryption.<br>
<br>
How does it work?<br>
<br>
1.) the plain text gets encrypted using a password<br>
2.) the encrypted result is rotated using a random key for each character until it is valid ascii<br>
3.) if the result is invalid, it is rotated more until valid.<br>
4.) the key gets encrypted with a password<br>
<br>
Caveats:<br>
-The length of the plain text can be guessed, because it equals the length of the decryption key<br>
-The algorithm is still prone to wordlist attacks<br>
<br>
Hey, isn't that asymetric encryption?<br>
Not really. The decryption key differes with each encryption attempt and is part of the encrypted text. Furthermore, the encryption password is still required for decryption.<br>
<br>
Hey, that's just layered encryption. Layered encryption only makes it more expensive to crack the algorithm<br>
It is layered encryption. But the goal is not to make an attack more cost effective or complex, it is to make the encrypted password logically uncrackable.<br>
<br>
Usage:<br>
<br>
CRincewind rw=new CRincewind("pluginlibrary.dll", 512);<br>
String enc=rw.encryptString("data","password1","password2");<br>
String dec=rw.decryptString(enc,"password1","password2");<br>
<br>
Creating custom plugins:<br>
Derive from the interface found in LibRincewindPlugin.
