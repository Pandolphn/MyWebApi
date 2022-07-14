using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.RAS
{
    
        /// <summary>
        /// Summary: RSA非对称加密算法实现
        /// API详情请参考: http://www.bouncycastle.org/csharp/
        /// 密钥默认长度为1024（应该够用吧），可以解密的源字符串最大长度为：密钥长度/8-11，这里就是1024/8-11=117
        /// Author: Lee Liu
        /// Date: 20181031
        /// </summary>
        [Export("RSA", typeof(IRSAHelper))]
        public class RSAHelper : IRSAHelper
        {
            //设定编码方式为UTF-8
            private static Encoding Encoding_UTF8 = Encoding.UTF8;

            //全局变量: RSA公私密钥对
            private RSAKEY keyPair;

            //RSA引用，这里用作单例模式使用。
            private static RSAHelper rsa;

        #region 私有化无参构造方法
        //private RSAHelper()
        //{
        //    keyPair = GetKey();
        //}
        #endregion

        #region 单例模式，获取RSA类的实例
        /// <summary>
        /// 单例模式，获取RSA类的实例
        /// </summary>
        /// <returns></returns>
        //public static RSAHelper GetRSAInstance()
        //{
        //    if (rsa != null)
        //    {
        //        return rsa;
        //    }
        //    else
        //    {
        //        return new RSAHelper();
        //    }
        //}
        #endregion
        public RSAHelper()
        {
            keyPair = GetKey();
        }
        #region 实现IRSAHelper接口
        public string DecryptViaPrivateKey(string data, string privateKey)
            {
                return DecryptByPrivateKey(data, privateKey);
            }

            public string DecryptViaPublicKey(string data, string publicKey)
            {
                return DecryptByPublicKey(data, publicKey);
            }

            public string EncryptViaPrivateKey(string data, string privateKey)
            {
                return EncryptByPrivateKey(data, privateKey);
            }

            public string EncryptViaPublicKey(string data, string publicKey)
            {
                return EncryptByPublicKey(data, publicKey);
            }

            public string GetPrivateKey()
            {
                return keyPair.PrivateKey;
            }

            public string GetPublicKey()
            {
                return keyPair.PublicKey;
            }

            public void SetPrivateKey(string privateKey)
            {
                keyPair.PrivateKey = privateKey;
            }

            public void SetPublicKey(string publicKey)
            {
                keyPair.PublicKey = publicKey;
            }
            #endregion

            #region Key Pair结构体
            /// <summary>
            /// KEY 结构体
            /// </summary>
            public struct RSAKEY
            {
                /// <summary>
                /// 公钥
                /// </summary>
                public string PublicKey
                {
                    get;
                    set;
                }
                /// <summary>
                /// 私钥
                /// </summary>
                public string PrivateKey
                {
                    get;
                    set;
                }
            }
            #endregion

            #region 获取公私钥
            private RSAKEY GetKey()
            {
                //RSA密钥对的构造器  
                RsaKeyPairGenerator keyGenerator = new RsaKeyPairGenerator();

                //RSA密钥构造器的参数  
                RsaKeyGenerationParameters param = new RsaKeyGenerationParameters(
                    Org.BouncyCastle.Math.BigInteger.ValueOf(3),
                    new Org.BouncyCastle.Security.SecureRandom(),
                    1024,   //密钥长度  
                    25);
                //用参数初始化密钥构造器  
                keyGenerator.Init(param);
                //产生密钥对  
                AsymmetricCipherKeyPair keyPair = keyGenerator.GenerateKeyPair();
                //获取公钥和密钥  
                AsymmetricKeyParameter publicKey = keyPair.Public;
                AsymmetricKeyParameter privateKey = keyPair.Private;

                SubjectPublicKeyInfo subjectPublicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
                PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);

                Asn1Object asn1ObjectPublic = subjectPublicKeyInfo.ToAsn1Object();

                byte[] publicInfoByte = asn1ObjectPublic.GetEncoded("UTF-8");
                Asn1Object asn1ObjectPrivate = privateKeyInfo.ToAsn1Object();
                byte[] privateInfoByte = asn1ObjectPrivate.GetEncoded("UTF-8");

                RSAKEY item = new RSAKEY()
                {
                    PublicKey = Convert.ToBase64String(publicInfoByte),
                    PrivateKey = Convert.ToBase64String(privateInfoByte)
                };
                return item;
            }
            #endregion

            #region 获取公私钥参数
            /// <summary>
            /// 获取公钥参数
            /// </summary>
            /// <param name="keyBase64">公钥</param>
            /// <returns></returns>
            private AsymmetricKeyParameter GetPublicKeyParameter(string keyBase64)
            {
                keyBase64 = keyBase64.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                byte[] publicInfoByte = Convert.FromBase64String(keyBase64);
                Asn1Object pubKeyObj = Asn1Object.FromByteArray(publicInfoByte);//这里也可以从流中读取，从本地导入   
                AsymmetricKeyParameter pubKey = PublicKeyFactory.CreateKey(publicInfoByte);
                return pubKey;
            }

            /// <summary>
            /// 获取私钥参数
            /// </summary>
            /// <param name="keyBase64">私钥</param>
            /// <returns></returns>
            private AsymmetricKeyParameter GetPrivateKeyParameter(string keyBase64)
            {
                keyBase64 = keyBase64.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                byte[] privateInfoByte = Convert.FromBase64String(keyBase64);
                // Asn1Object priKeyObj = Asn1Object.FromByteArray(privateInfoByte);//这里也可以从流中读取，从本地导入   
                // PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
                AsymmetricKeyParameter priKey = PrivateKeyFactory.CreateKey(privateInfoByte);
                return priKey;
            }
            #endregion

            #region 使用私钥加密内容
            /// <summary>
            /// 私钥加密
            /// </summary>
            /// <param name="data">加密内容</param>
            /// <param name="privateKey">私钥（Base64后的）</param>
            /// <returns>返回Base64内容</returns>
            private string EncryptByPrivateKey(string data, string privateKey)
            {
                //非对称加密算法，加解密用  
                IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());

                //加密  
                try
                {
                    engine.Init(true, GetPrivateKeyParameter(privateKey));
                    byte[] byteData = Encoding_UTF8.GetBytes(data);
                    var ResultData = engine.ProcessBlock(byteData, 0, byteData.Length);
                    return Convert.ToBase64String(ResultData);
                    //Console.WriteLine("密文（base64编码）:" + Convert.ToBase64String(testData) + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion

            #region 使用私钥解密内容
            /// <summary>
            /// 私钥解密
            /// </summary>
            /// <param name="data">待解密的内容</param>
            /// <param name="privateKey">私钥（Base64编码后的）</param>
            /// <returns>返回明文</returns>
            private string DecryptByPrivateKey(string data, string privateKey)
            {
                data = data.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                //非对称加密算法，加解密用  
                IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());

                //解密  
                try
                {
                    engine.Init(false, GetPrivateKeyParameter(privateKey));
                    byte[] byteData = Convert.FromBase64String(data);
                    var ResultData = engine.ProcessBlock(byteData, 0, byteData.Length);
                    return Encoding_UTF8.GetString(ResultData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion

            #region 使用公钥加密内容
            /// <summary>
            /// 公钥加密
            /// </summary>
            /// <param name="data">加密内容</param>
            /// <param name="publicKey">公钥（Base64编码后的）</param>
            /// <returns>返回Base64内容</returns>
            private string EncryptByPublicKey(string data, string publicKey)
            {
                //非对称加密算法，加解密用  
                IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());

                //加密  
                try
                {
                    engine.Init(true, GetPublicKeyParameter(publicKey));
                    byte[] byteData = Encoding_UTF8.GetBytes(data);
                    var ResultData = engine.ProcessBlock(byteData, 0, byteData.Length);
                    return Convert.ToBase64String(ResultData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion

            #region 使用公钥解密内容
            /// <summary>
            /// 公钥解密
            /// </summary>
            /// <param name="data">待解密的内容</param>
            /// <param name="publicKey">公钥（Base64编码后的）</param>
            /// <returns>返回明文</returns>
            private string DecryptByPublicKey(string data, string publicKey)
            {
                data = data.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                //非对称加密算法，加解密用  
                IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());

                //解密  
                try
                {
                    engine.Init(false, GetPublicKeyParameter(publicKey));
                    byte[] byteData = Convert.FromBase64String(data);
                    var ResultData = engine.ProcessBlock(byteData, 0, byteData.Length);
                    return Encoding_UTF8.GetString(ResultData);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion
        }
    
}
