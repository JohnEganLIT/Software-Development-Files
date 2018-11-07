using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Security {
    public class SecureHash {
        private HashAlgorithm algorithm;

        public enum HashType { MD5, SHA1, SHA256, SHA512 }

        public SecureHash() {
            algorithm = new MD5CryptoServiceProvider();
        }

        public SecureHash(HashType hashType) {
            switch (hashType) {
            default:
            case HashType.MD5: algorithm = new MD5CryptoServiceProvider(); break;
            case HashType.SHA1: algorithm = new SHA1Managed(); break;
            case HashType.SHA256: algorithm = new SHA256Managed(); break;
            case HashType.SHA512: algorithm = new SHA512Managed(); break;
            }
        }

        public string Compute(string plainText) {
            if (algorithm == null) algorithm = new MD5CryptoServiceProvider();
            byte[] hashValue = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return hashValue.Aggregate(string.Empty, (current, x) => current + string.Format("{0:x2}", x));
        }
    }
}
