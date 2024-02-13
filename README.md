# LibRincewind
A post-quantom cryptographic, bruteforce protected aporach for encryption of plain text ASCII.<br>
<br>
Synopsis:<br>
Normal encryption of plain text can theoretically be broken by quantum computers. This is due to the fact that decryption attempts with a failure password will result in non-ASCII data.<br>

LibRincewind simply combines a symetrical alogrithm with a rotational algorithm.<br>
A key used for decryption is being generated which contains the rotation delta for each character. This key gets encrypted, too.<br>
Thus, two passwords will be used for encryption (this means that you can also use one password and split it up).<br>
<br>
Caveats:<br>
The length of the plain text can be guessed, because it equals the length of the decryption key.<br>
<br>
Hey, isn't that asymetric encryption?<br>
Not really. The decryption key differes with each encryption attempt. Furthermore, the encryption password is still required for decryption.<br>
<br>
Usage:<br>
<br>
CRincewind rw=new CRincewind(<pluginlibrary>, 512);<br>
String enc=rw.encryptString("data","password1","password2");<br>
String dec=rw.decryptString(enc,"password1","password2");<br>
<br>
Creating custom plugins:<br>
Derive from the interface found in LibRincewindPlugin.<br>

