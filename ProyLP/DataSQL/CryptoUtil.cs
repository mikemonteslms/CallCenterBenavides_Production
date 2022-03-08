using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for CryptoUtil
/// </summary>
public class CryptoUtil
{
//    8 bytes randomly selected for both the Key and the Initialization Vector
//    the IV is used to encrypt the first block of text so that any repetitive 
//    patterns are not apparent
//    private byte[] KEY_64 = {42, 16, 93, 156, 78, 4, 218, 32};
    private byte[] KEY_64 = Encoding.ASCII.GetBytes("esto es una prueba");
    private byte[] IV_64 = Encoding.ASCII.GetBytes("otra prueba");

//    24 byte or 192 bit key and IV for TripleDES
    private byte[] KEY_192 = Encoding.ASCII.GetBytes("123456789012345678901234");
//    private byte[] KEY_192 = { 01, 02, 03, 04, 05, 06, 07, 08, 01, 02, 03, 04, 05, 06, 07, 
//        08, 01, 02, 03, 04, 05, 06, 07, 08};
    private byte[] IV_192 = Encoding.ASCII.GetBytes("1234567890123456");
//            42, 5, 62, 83, 184, 7, 209, 13, 
//            145, 23, 200, 58, 173, 10, 121, 222};

//    Standard DES encryption
    public string Encrypt(string value)
    {
        if (value != "")
        {
            DESCryptoServiceProvider cryptoProvider = 
                new DESCryptoServiceProvider();
            cryptoProvider.Mode = CipherMode.ECB;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64,IV_64), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);

            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();

//            convert back to a string
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }
        return "";
    }


    //Standard DES decryption
    public string Decrypt(string value)
    {
        if (value != "")
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            cryptoProvider.Mode = CipherMode.ECB;
            //convert from string to byte array
            byte[] buffer = Convert.FromBase64String(value);
            MemoryStream  ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
        return "";
    }

    //TRIPLE DES encryption
    public string EncryptTripleDES(string value)
    {
        if (value != "")
        {
            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            cryptoProvider.Mode = CipherMode.ECB;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);

            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();

            //convert back to a string
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }
        return "";
    }

    //TRIPLE DES decryption
    public string DecryptTripleDES(string value)
    {
        if (value != "")
        {
            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            cryptoProvider.Mode = CipherMode.ECB;
            //convert from string to byte array
            byte[] buffer = Convert.FromBase64String(value);
            MemoryStream ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
        return "";
    }
    public string htmlEncodeTripleDES_1(string value)
    {
        string encode = EncryptTripleDES(value);
        encode = htmlEncode(encode);
        return encode;
    }
    public string htmlEncodeTripleDES(string value)
    {
        string encode = EncryptTripleDES(value);
        encode = htmlEncode(encode);
        encode = encode.Replace('%', '_');
        return encode;
    }
    public string htmlDecodeTripleDES(string value)
    {
        string decode = value.Replace('_', '%');
        decode = htmlDecode(decode);
        decode = DecryptTripleDES(decode);
        return decode;
    }
    public string htmlEncode(string value)
    {
        string encode = HttpContext.Current.Server.UrlEncode(value);
        return encode;
    }
    public string htmlDecode(string value)
    {
        string decode = HttpContext.Current.Server.UrlDecode(value);
        return decode;
    }
	public CryptoUtil()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
