//-------------------------------------------------------------------------------------------------
//
//                                 Oliver Abraham
//                              www.oliver-abraham.de
//                              mail@oliver-abraham.de
//
//
//              Klasse für die Verschlüsselung und Entschlüsselung von Daten
//
//-------------------------------------------------------------------------------------------------
//
// Literatur:
// http://www.codeproject.com/KB/security/SimpleEncryption.aspx
//
//
// Wichtiger Hinweis:
//
// The Annoying File Dependency in Encryption.Asymmetric
// Unfortunately, Microsoft chose to provide some System.Security.Cryptography functionality 
// through the existing COM-based CryptoAPI. Typically this is no big deal; lots of things in 
// .NET are delivered via COM interfaces. However, there is one destructive side effect in 
// this case: asymmetric encryption, which in my opinion should be an entirely in-memory 
// operation, has a filesystem "key container" dependency:
// 
// Even worse, this weird little "key container" file usually goes to the current user's folder! 
// I have specified a machine folder as documented in this Microsoft knowledge base article. 
// Every time we perform an asymmetric encryption operation, a file is created and then 
// destroyed in the C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\
// MachineKeys folder. It is simply unavoidable, which you can see for yourself by opening this 
// folder and watching what happens to it when you make asymmetric encryption calls. Make sure 
// whatever account .NET is running as (ASP.NET, etc.) has permission to this folder!
// 
//-------------------------------------------------------------------------------------------------

using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Abraham.Security
{
    /// <summary>
    /// Verschlüsselt und Entschlüsselt Texte mit dem AES-Algorithmus
    /// </summary>
    public class Encryption
	{
		#region ------------- Properties ----------------------------------------------------------
        public string Password
        {
            get 
            {
                return _kennwort; 
            }

            set
            {
                _kennwort = value;
                KennwortlängePrüfenUndAnpassen(AES.LegalKeySizes);
                CreateCryptoStreams(); 
            }
        }
		#endregion



		#region ------------- Fields --------------------------------------------------------------
		private string _kennwort;
        private AesCryptoServiceProvider AES = null;
        private ICryptoTransform EncryptTransformer = null;
        private ICryptoTransform DecryptTransformer = null;
        private CryptoStream EncryptInStream = null;
        private CryptoStream DecryptInStream = null;
        private MemoryStream EncryptOutStream = null;
        private MemoryStream DecryptOutStream = null;
        private bool EncryptFirstTime = true;
        private bool DecryptFirstTime = true;
        private bool KennwortAuffüllen = true;
		#endregion



		#region ------------- Init ----------------------------------------------------------------
        /// <summary>
        /// Erzeugt eine neue Instanz mit dem Standardprovider AES
        /// </summary>
        public Encryption()
        {
            AES = new AesCryptoServiceProvider();
        }
		#endregion



		#region ------------- Methods -------------------------------------------------------------
        /// <summary>
        /// String mit dem AES-Algorithmus verschlüsseln
        /// </summary>
        /// 
        /// <example>
        /// Encryption enc = new Encryption();
        /// string Ausgabe = enc.Encrypt("Eingabe", Kennwort);
        /// </example>
        /// 
        /// <param name="input">Eingabedaten</param>
        public string Encrypt(string input)
        {
            if (!EncryptFirstTime)
                CreateCryptoStreams();
            EncryptFirstTime = false;

           
            // Um am Ende nach dem Entschlüsseln genau die Anzahl an Zeichen 
            // rauszubekommen, die wir reinschieben, schreiben wir zunächst die 
            // Zeichenanzahl in den Strom. Beim Entschlüsseln wissen wir das 
            // und können die Zahl wieder auslesen und damit den Block trimmen.
            input = string.Format("{0:D12}", input.Length) + input;


            byte[] InputBytes = Encoding.UTF8.GetBytes(input);
            int Länge = InputBytes.Length;


            // Unverschlüsselte Daten in den Strom schreiben
            EncryptInStream.Write(InputBytes, 0, Länge);


            // Da die Verschlüsselungsfunktion mit Blöcken à 16 Bytes (InBlockSize) 
            // arbeitet, müssen wir die Eingabe immer auf ein Vielfaches von 16 bringen.
            // Sonst fehlen bis zu 15 Bytes im Chiffrat. (die letzten 15 Bytes)s
            AuffüllenAufNächsteBlockgrenze(EncryptInStream, Länge, EncryptTransformer.InputBlockSize);

            // Verschlüsselte Daten auslesen
            byte[] Ausgabe = GetBytesFromStream(EncryptOutStream);
            return Convert.ToBase64String(Ausgabe);
        }

        /// <summary>
        /// String mit dem AES-Algorithmus entschlüsseln
        /// </summary>
        /// 
        /// <example>
        /// Encryption enc = new Encryption();
        /// string Ausgabe = enc.Decrypt("asdkjfhasidufzguiergt", Kennwort);
        /// </example>
        /// 
        /// <param name="input">Eingabedaten</param>
        public string Decrypt(string input)
        {
            if (!DecryptFirstTime)
                CreateCryptoStreams(); // Reinitialisierung fürs nächste Mal
            DecryptFirstTime = false;

            byte[] InputBytes = Convert.FromBase64String(input);
            DecryptInStream.Write(InputBytes, 0, InputBytes.Length);


            // Auch für die die Entschlüsselung müssen wir mehr Bytes reinschieben
            // Ich habe das nicht nächer untersucht. Wenn man 16 Bytes reinschiebt,
            // kommt nichts raus. Wenn man nochmal die Blockgröße reinschiebt,
            // kommen die 16 Bytes raus.
            int a = DecryptTransformer.InputBlockSize;
            byte[] Auffüller = new byte[a];
            DecryptInStream.Write(Auffüller, 0, Auffüller.Length);


            // Entschlüsselten Text vom Ausgabestrom lesen
            byte[] AusgabeBytes = GetBytesFromStream(DecryptOutStream);
            string Ausgabe = Encoding.UTF8.GetString(AusgabeBytes);


            // Jetzt holen wir die Original-Stringlänge (12 Ziffern) wieder raus
            // und trimmen damit den entschlüsselten String
            string Längenstring = Ausgabe.Substring(0, 12);
            Ausgabe = Ausgabe.Remove(0, 12);
            int Länge = Convert.ToInt32(Längenstring);

            return Ausgabe.Substring(0, Länge);
        }
		#endregion



		#region ------------- Implementation ------------------------------------------------------
        private void AuffüllenAufNächsteBlockgrenze(CryptoStream Stream, int Länge, int InBlockSize)
        {
            int Nächste16ByteGrenze = ((Länge / InBlockSize) + 1) * InBlockSize;
            int Differenz = Nächste16ByteGrenze - Länge;
            byte[] Auffüller = new byte[Differenz];
            Stream.Write(Auffüller, 0, Auffüller.Length);
        }

        private byte[] GetBytesFromStream(MemoryStream stream)
        {
            long AnzahlBytes = stream.Length;
            byte[] byteArray = new byte[AnzahlBytes];
            stream.Seek(0, SeekOrigin.Begin);
            int count = stream.Read(byteArray, 0, (int) AnzahlBytes);
            return byteArray;
        }

        private void CreateCryptoStreams()
        {
            EncryptOutStream = new MemoryStream();
            DecryptOutStream = new MemoryStream();

            // Die AES-Encryption möchte gerne einen Initialisierungsvektor in 128 Bits Länge haben
            string Initialisierungsvektor = Password;
            if (Initialisierungsvektor.Length > 128 / 8)
                Initialisierungsvektor = Initialisierungsvektor.Substring(0, 128 / 8);


            //---------------------------------------------------------------------------
            // Datentyp des übergebenen Kennwort-Strings umwandeln
            // (Schlüssel und Initialisierungsvektor für die Encryption)
            //---------------------------------------------------------------------------
            byte[] tdesKey = ASCIIEncoding.ASCII.GetBytes(Password);
            byte[] tdesIV  = ASCIIEncoding.ASCII.GetBytes(Initialisierungsvektor);


            EncryptTransformer = AES.CreateEncryptor(tdesKey, tdesIV);
            DecryptTransformer = AES.CreateDecryptor(tdesKey, tdesIV);

            EncryptInStream = new CryptoStream(EncryptOutStream, EncryptTransformer, CryptoStreamMode.Write);
            DecryptInStream = new CryptoStream(DecryptOutStream, DecryptTransformer, CryptoStreamMode.Write);
        }

        /// <summary>
        /// Prüfen, ob das übergebene Kennwort eine passende Länge hat
        /// </summary>
        ///
        /// <remarks>
        /// Die Encryptionsklasse sagt uns, wie die Kennwortlänge sein muss
        /// Wenn gewünscht, kann die Funktion das übergebene Kennwort 
        /// auf die richtige Länge bringen.
        /// </remarks>
        ///
        /// <example>
        /// Die Klasse sagt MinSize=128, MaxSize=192, SkipSize=64
        /// Das bedeutet, dass das Kennwort 128 oder 192 Bits lang sein muss.
        /// </example>
        /// 
        /// <param name="LegalKeySizes">
        /// Hier in dieser Klasse finden wir die Informationen 
        /// über mögliche Kennwortlängen.
        /// </param>
        /// 
        /// <returns>
        /// 0 - OK
        /// 1 = Das Kennwort hat keine für das Encryptionsverfahren erlaubte Länge (zu lang oder zu kurz)
        /// 2 = Das Kennwort hat keine erlaubte Länge und wurde angepaßt
        /// </returns>
        private void KennwortlängePrüfenUndAnpassen(KeySizes[] LegalKeySizes)
        {
            int KennwortlängeInBits = _kennwort.Length * 8;
            bool Gefunden = false;
            int MaximallängeInBits = 0;
            foreach (KeySizes size in LegalKeySizes)
            {
                // Alle erlaubten Kennwortlängen durchprobieren
                for (int LängeInBits = size.MinSize; LängeInBits <= size.MaxSize; LängeInBits += size.SkipSize)
                {
                    if (LängeInBits > MaximallängeInBits)
                        MaximallängeInBits = LängeInBits;

                    if (KennwortlängeInBits == LängeInBits)
                        Gefunden = true;
                }
                if (Gefunden)
                    break;
            }

            if (Gefunden == false)
            {
                if (KennwortAuffüllen)
                {
                    // Wir haben beim Testen der Kennwortlängen das Maximum aller erlaubten Längen gebildet.
                    // Wir schneiden das Kennwort auf die Maximallänge ab
                    int Maximallänge = MaximallängeInBits / 8;
                    if (_kennwort.Length > Maximallänge)
                        _kennwort = _kennwort.Substring(0,Maximallänge);

                    // bzw. füllen es auf, in dem wir die eigenen Zeichen immer wieder anhängen
                    else
                    {
                        while (_kennwort.Length < Maximallänge)
                        {
                            _kennwort += _kennwort;
                            if (_kennwort.Length > Maximallänge)
                                _kennwort = _kennwort.Substring(0, Maximallänge);
                        }
                    }
                    return;
                }
                else
                    throw new FalscheKennwortlängeException("Das Kennwort hat keine für das Encryptionsverfahren erlaubte Länge (zu lang oder zu kurz)");
            }
        }
		#endregion
    }


    /// <summary>
    /// Kennzeichnet eine unbrauchbare Kennwortlänge, um etwas zu verschlüsseln
    /// </summary>
    public class FalscheKennwortlängeException : Exception
    {
        /// <summary>
        /// Kennzeichnet eine unbrauchbare Kennwortlänge, um etwas zu verschlüsseln
        /// </summary>
        public FalscheKennwortlängeException() 
        { 
        }

        /// <summary>
        /// Kennzeichnet eine unbrauchbare Kennwortlänge, um etwas zu verschlüsseln
        /// </summary>
        public FalscheKennwortlängeException(string message) 
        { 
        }
    }
}
