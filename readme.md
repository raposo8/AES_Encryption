# AES Encryption Project

This project uses the AES encryption algorithm. It includes methods for both encrypting and decrypting a message. However, if you run both methods simultaneously, you will not see the encryption result. The functions are commented in the code; to encrypt, you need to uncomment the encryption function and comment out the decryption function, and vice versa.

## How It Works

The code accesses a file on your machine via the provided path, reads its content, and replaces it with the encrypted/decrypted data.

## Prerequisites

For the encryption to work, you need to provide two keys: the password (key) and the initialization vector (IV). They must have the same number of characters as shown in the example in the code.

## Getting Started

1. **Clone the repository:**

   ```bash
   git clone https://github.com/<USERNAME>/<REPOSITORY>.git
   cd <REPOSITORY>

2. **Setup the paths in the code:**

   Change the path to the location of your files
   ```csharp
   string path = "C:\\path\\to\\your\\file.txt";
   string pathkey = "C:\\path\\to\\your\\key.txt";
   string pathiv = "C:\\path\\to\\your\\iv.txt";

3. **Run the code:**

To encrypt, uncomment the encryption part and comment out the decryption part.
To decrypt, uncomment the decryption part and comment out the encryption part.
   ```csharp
   //Encrypt
   //ciphertext = Cripto(plaintext, key1, iv1);
   //StreamWriter sw = new StreamWriter(path);
   //sw.WriteLine(Convert.ToBase64String(ciphertext));
   //sw.Close();

   //Decrypt
   string decryptedText = Decript(plaintext, key1, iv1);
   StreamWriter sw = new StreamWriter(path);
   sw.WriteLine(decryptedText);
   sw.Close();