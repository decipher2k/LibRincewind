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
-I'm not 100% sure if the password authentication part is really safe. theoretically, it should increase the complexity by about 1/3 +/- the costs for trying out the first 2/3 compared to sqrt when cracking hashed passwords using grover.<br>
<br>
Usage:<br>
<br>
Encryption of passwords using a main password (password managers):<br>
CRincewind rw=new CRincewind("pluginlibrary.dll", 512);<br>
String enc=rw.encryptString("data","password1","password2");<br>
String dec=rw.decryptString(enc,"password1","password2");<br>
<br>
Password authentication (password login):<br>
CRincewind rw=new CRincewind("pluginlibrary.dll", 512):<br>
//store this in the db<br>
String enc=rw.generatePwAuth(password);<br>
//test for validity<br>
bool valid=isPwAuthValid(password,enc);<br>
<br>
Creating custom plugins:<br>
<br>
Implement the interface found in LibRincewindPlugin.<br>
<br>
ToDo:<br>
IV's for each character<br><br>
Update v1.1:<br>
-Added demo sourcecode<br>
-Added password authentication
<br><br>
Contact E-Mail: decipher2k20@gmail.com
