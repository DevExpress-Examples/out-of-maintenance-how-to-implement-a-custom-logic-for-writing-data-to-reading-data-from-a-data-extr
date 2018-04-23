using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using DevExpress.DashboardCommon;

namespace Dashboard_CustomExtractDriver {
    public class ExtractEncryptionDriver : ICustomExtractDriver {

        public IDriverReadSession CreateReadSession(string resourceName) {
            return new EncryptionReadSession(FileExtractDriver.Instance.CreateReadSession(resourceName));
        }
        public IDriverWriteSession CreateWriteSession(string resourceName) {
            return new EncryptionWriteSession(FileExtractDriver.Instance.CreateWriteSession(resourceName));
        }
    }

    public class EncryptionWriteSession : IDriverWriteSession {
        IDriverWriteSession writeSession;

        public EncryptionWriteSession(IDriverWriteSession writeSession) {
            this.writeSession = writeSession; 
        }
        public void Dispose() {
            writeSession.Dispose();
        }
        public void SetPage(Guid pageID, byte[] data) {
            writeSession.SetPage(pageID, Encrypt(data));
        }
        byte[] Encrypt(byte[] page) {
            byte[] entropy = { 1, 2, 3 };
            byte[] encryptedPage = ProtectedData.Protect(page, entropy, DataProtectionScope.CurrentUser);
            return encryptedPage;
        }
    }

    public class EncryptionReadSession : IDriverReadSession {
        IDriverReadSession readSession;
        public EncryptionReadSession(IDriverReadSession readSession) {
            this.readSession = readSession;
        }
        public void Dispose() {
            readSession.Dispose();
        }
        byte[] Decrypt(byte[] page) {
            byte[] entropy = { 1, 2, 3 };
            byte[] decryptedPage = ProtectedData.Unprotect(page, entropy, DataProtectionScope.CurrentUser);
            return decryptedPage;
        }
        public byte[] GetPage(Guid pageID) {
            return Decrypt(readSession.GetPage(pageID));
        }
        public IEnumerable<Guid> GetPageIDs() {
            return readSession.GetPageIDs();
        }
    }
}