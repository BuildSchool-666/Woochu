using System;
using System.Security.Cryptography;
using Front.Service.Payment.Enums;

namespace Front.Service.Payment.Interfaces
{
    /// <summary>
    /// 綠界服務介接的檢查碼機制。
    /// </summary>
    public interface ICheckMac
    {
        /// <summary>
        /// 產生檢查碼。
        /// </summary>
        string GetValue(IPayment payment, EHashAlgorithm encryptType = EHashAlgorithm.SHA256);
    }
}

