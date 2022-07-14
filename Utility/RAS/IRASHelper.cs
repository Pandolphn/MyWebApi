using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.RAS
{
   
        /// <summary>
        /// Summary: RSAHelper接口
        /// Author: Lee Liu
        /// Date: 20181031
        /// </summary>
        public interface IRSAHelper
        {
            /// <summary>
            /// 使用私钥解密
            /// </summary>
            /// <param name="data">要解密的数据</param>
            /// <param name="privateKey">私钥</param>
            /// <returns>明文</returns>
            string DecryptViaPrivateKey(string data, string privateKey);

            /// <summary>
            /// 使用公钥解密
            /// </summary>
            /// <param name="data">要解密的数据</param>
            /// <param name="publicKey">公钥</param>
            /// <returns>明文</returns>
            string DecryptViaPublicKey(string data, string publicKey);

            /// <summary>
            /// 使用私钥加密
            /// </summary>
            /// <param name="data">要加密的数据</param>
            /// <param name="privateKey">私钥</param>
            /// <returns>密文</returns>
            string EncryptViaPrivateKey(string data, string privateKey);

            /// <summary>
            /// 使用公钥加密
            /// </summary>
            /// <param name="data">要加密的数据</param>
            /// <param name="publicKey">公钥</param>
            /// <returns>密文</returns>
            string EncryptViaPublicKey(string data, string publicKey);

            /// <summary>
            /// 获取公钥
            /// </summary>
            /// <returns>返回公钥字符串</returns>
            string GetPublicKey();

            /// <summary>
            /// 获取私钥
            /// </summary>
            /// <returns>返回私钥字符串</returns>
            string GetPrivateKey();

            /// <summary>
            /// 设置公钥
            /// </summary>
            /// <param name="publicKey">公钥</param>
            void SetPublicKey(string publicKey);

            /// <summary>
            /// 设置私钥
            /// </summary>
            /// <param name="privateKey">私钥</param>
            void SetPrivateKey(string privateKey);
        }
   
}
