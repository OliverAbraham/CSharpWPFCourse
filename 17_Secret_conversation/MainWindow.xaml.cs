using Abraham.Security;
using Abraham.String;
using System;
using System.Windows;
using System.Windows.Controls;

namespace _17_Secret_conversation
{
	public partial class MainWindow : Window
	{
        #region ------------- Fields --------------------------------------------------------------
        private const string _newLine = "\r\n";
		private Encryption   _encryptor;
        private long         _lastEntryTop;
        private long         _lastEntryBottom;
		#endregion



		#region ------------- Init ----------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            _encryptor = new Encryption();
            _encryptor.Password = "sdk$jfh&asiudfh(kjg73§§453tkadgkd";
        }
		#endregion



		#region ------------- Implementation ------------------------------------------------------

		// We want to allow typing in both entryfields, but prevent an infinit loop.
		// because when your typing in the upper field, you will get firstly the Textbox_Top_TextChanged event.
		// then, when you put new text into the lower entryfield, you will force also an event there.
		// The "trick" is to look how long the delay between the two events is.
		// Is it under 1 second, then we do nothing in the other entryfield, because it must have been the automatic, not the user.

        private void Textbox_Top_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (TextboxTop == null || TextboxBottom == null)
				return;
			if (ElapsedTime(_lastEntryBottom) < 1000) // prevent an infinite loop
				return;
			_lastEntryTop = DateTime.Now.Ticks;

			Take_upper_text_encrypt_and_display_below();
		}

		private void Textbox_Bottom_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (TextboxTop == null || TextboxBottom == null)
				return;
			if (ElapsedTime(_lastEntryTop) < 1000) // prevent an infinite loop
				return;
			_lastEntryBottom = DateTime.Now.Ticks;

			Take_lower_text_decrypt_and_display_above();
		}

		private long ElapsedTime(long ticks)
        {
            return (DateTime.Now.Ticks - ticks) / 10000;
        }

		private void Take_upper_text_encrypt_and_display_below()
		{
			var encryptedText = _encryptor.Encrypt(TextboxTop.Text);
			TextboxBottom.Text = "[BEG]" + _newLine + encryptedText + _newLine + "[END]";
		}

		private void Take_lower_text_decrypt_and_display_above()
		{
			try
			{
				string Text = TextboxBottom.Text.FetchTextBetween("[BEG]" + _newLine, _newLine + "[END]");
				var entschlüsselterText = _encryptor.Decrypt(Text);
				TextboxTop.Text = entschlüsselterText;
			}
			catch (Exception)
			{
				TextboxTop.Text = "Invalid cipher text";
			}
		}
		#endregion
	}
}
