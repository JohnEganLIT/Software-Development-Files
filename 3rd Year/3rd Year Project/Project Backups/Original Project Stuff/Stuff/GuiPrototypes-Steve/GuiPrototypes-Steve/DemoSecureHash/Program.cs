using Security;
using System;

namespace DemoSecureHash {
    class Program {
        public static Logger logger;

        static void Main(string[] args) {
            logger = new Logger();
            logger.Open("hasher.log");

            for (;;) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter Plaintext (empty string to exit): ");
                Console.ResetColor();
                string plainText = Console.ReadLine();
                if (plainText == "") break;

                Console.ForegroundColor = ConsoleColor.Green;
                SecureHash md5 = new SecureHash(SecureHash.HashType.MD5);
                Console.Write("MD5 HASH: {0}\n", md5.Compute(plainText));

                Console.ForegroundColor = ConsoleColor.Cyan;
                SecureHash sha1 = new SecureHash(SecureHash.HashType.SHA1);
                Console.Write("SHA1 HASH: {0}\n", sha1.Compute(plainText));

                Console.ForegroundColor = ConsoleColor.Green;
                SecureHash sha256 = new SecureHash(SecureHash.HashType.SHA256);
                Console.Write("SHA256 HASH: {0}\n", sha256.Compute(plainText));

                Console.ForegroundColor = ConsoleColor.Cyan;
                SecureHash sha512 = new SecureHash(SecureHash.HashType.SHA512);
                Console.Write("SHA512 HASH: {0}\n", sha512.Compute(plainText));
            }
            logger.Close();
        }
    }
}
