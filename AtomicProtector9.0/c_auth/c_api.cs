using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace c_auth
{
	// Token: 0x0200003E RID: 62
	public class c_api
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00002460 File Offset: 0x00000660
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00002467 File Offset: 0x00000667
		private static string program_key { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0000246F File Offset: 0x0000066F
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00002476 File Offset: 0x00000676
		private static string enc_key { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0000247E File Offset: 0x0000067E
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00002485 File Offset: 0x00000685
		private static string iv_key { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000125 RID: 293 RVA: 0x0000248D File Offset: 0x0000068D
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00002494 File Offset: 0x00000694
		private static string session_id { get; set; }

		// Token: 0x06000127 RID: 295 RVA: 0x000176D4 File Offset: 0x000158D4
		public static void c_init(string c_version, string c_program_key, string c_encryption_key)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					webClient.Headers["User-Agent"] = c_api.user_agent;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(c_encryption.pin_public_key);
					c_api.program_key = c_program_key;
					c_api.iv_key = c_encryption.iv_key();
					c_api.enc_key = c_encryption_key;
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["version"] = c_encryption.encrypt(c_version, c_api.enc_key, "default_iv");
					nameValueCollection["session_iv"] = c_encryption.encrypt(c_api.iv_key, c_api.enc_key, "default_iv");
					nameValueCollection["api_version"] = c_encryption.encrypt("3.2b", c_api.enc_key, "default_iv");
					nameValueCollection["program_key"] = c_encryption.byte_arr_to_str(Encoding.UTF8.GetBytes(c_api.program_key));
					NameValueCollection data = nameValueCollection;
					string @string = Encoding.UTF8.GetString(webClient.UploadValues(c_api.api_link + "handler.php?type=init", data));
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
					string text = @string;
					string text2 = text;
					if (text2 != null)
					{
						if (text2 == "program_doesnt_exist")
						{
							MessageBox.Show("Tell hugzho the program doesnt exist", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Environment.Exit(0);
							goto IL_261;
						}
						if (text2.Equals(c_encryption.encrypt("killswitch_is_enabled", c_api.enc_key, "default_iv")))
						{
							MessageBox.Show("Tell hugzho to disable the killswitch", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Environment.Exit(0);
							goto IL_261;
						}
						string text3 = text2;
						if (text3.Equals(c_encryption.encrypt("wrong_version", c_api.enc_key, "default_iv")))
						{
							MessageBox.Show("Tell hugzho to fix program version", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Environment.Exit(0);
							goto IL_261;
						}
						string text4 = text2;
						if (text4.Equals(c_encryption.encrypt("old_api_version", c_api.enc_key, "default_iv")))
						{
							MessageBox.Show("Tell hugzho to update API", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Environment.Exit(0);
							goto IL_261;
						}
					}
					string[] array = c_encryption.decrypt(@string, c_api.enc_key, "default_iv").Split(new char[]
					{
						'|'
					});
					c_api.iv_key += array[1];
					c_api.session_id = array[2];
					IL_261:;
				}
			}
			catch (CryptographicException)
			{
				MessageBox.Show("Something went wrong, please try again.", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000179D8 File Offset: 0x00015BD8
		public static bool c_login(string c_username, string c_password, string c_hwid = "default")
		{
			bool flag = c_hwid == "default";
			if (flag)
			{
				c_hwid = WindowsIdentity.GetCurrent().User.Value;
			}
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					webClient.Headers["User-Agent"] = c_api.user_agent;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(c_encryption.pin_public_key);
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["username"] = c_encryption.encrypt(c_username, c_api.enc_key, c_api.iv_key);
					nameValueCollection["password"] = c_encryption.encrypt(c_password, c_api.enc_key, c_api.iv_key);
					nameValueCollection["hwid"] = c_encryption.encrypt(c_hwid, c_api.enc_key, c_api.iv_key);
					nameValueCollection["sessid"] = c_encryption.byte_arr_to_str(Encoding.UTF8.GetBytes(c_api.session_id));
					NameValueCollection data = nameValueCollection;
					string text = c_encryption.decrypt(Encoding.UTF8.GetString(webClient.UploadValues(c_api.api_link + "handler.php?type=login", data)), c_api.enc_key, c_api.iv_key);
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
					string text2 = text;
					string text3 = text2;
					if (text3 != null)
					{
						if (text3 == "killswitch_is_enabled")
						{
							MessageBox.Show("The killswitch of the program is enabled, contact the developer", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							goto IL_2DC;
						}
						if (text3 == "invalid_username")
						{
							MessageBox.Show("Invalid username. Just Press ok if the key is right", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						if (text3 == "invalid_password")
						{
							MessageBox.Show("Invalid password", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						if (text3 == "user_is_banned")
						{
							MessageBox.Show("The user is banned", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						if (text3 == "no_sub")
						{
							MessageBox.Show("Your subscription is over", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						if (text3 == "invalid_hwid")
						{
							MessageBox.Show("Invalid HWID", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
						if (text3.Contains("logged_in"))
						{
							string[] array = text.Split(new char[]
							{
								'|'
							});
							c_userdata.username = array[1];
							c_userdata.email = array[2];
							c_userdata.expires = c_encryption.unix_to_date(Convert.ToDouble(array[3]));
							c_userdata.rank = Convert.ToInt32(array[4]);
							c_api.stored_pass = c_encryption.encrypt(c_password, c_api.enc_key, c_api.iv_key);
							return true;
						}
					}
					MessageBox.Show("Something went wrong, please try again.", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				IL_2DC:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				Environment.Exit(0);
				return false;
			}
			return false;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00017D1C File Offset: 0x00015F1C
		public static bool c_register(string c_username, string c_email, string c_password, string c_token, string c_hwid = "default")
		{
			bool flag = c_hwid == "default";
			if (flag)
			{
				c_hwid = WindowsIdentity.GetCurrent().User.Value;
			}
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					webClient.Headers["User-Agent"] = c_api.user_agent;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(c_encryption.pin_public_key);
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["username"] = c_encryption.encrypt(c_username, c_api.enc_key, c_api.iv_key);
					nameValueCollection["email"] = c_encryption.encrypt(c_email, c_api.enc_key, c_api.iv_key);
					nameValueCollection["password"] = c_encryption.encrypt(c_password, c_api.enc_key, c_api.iv_key);
					nameValueCollection["token"] = c_encryption.encrypt(c_token, c_api.enc_key, c_api.iv_key);
					nameValueCollection["hwid"] = c_encryption.encrypt(c_hwid, c_api.enc_key, c_api.iv_key);
					nameValueCollection["sessid"] = c_encryption.byte_arr_to_str(Encoding.UTF8.GetBytes(c_api.session_id));
					NameValueCollection data = nameValueCollection;
					string text = c_encryption.decrypt(Encoding.UTF8.GetString(webClient.UploadValues(c_api.api_link + "handler.php?type=register", data)), c_api.enc_key, c_api.iv_key);
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
					string text2 = text;
					string text3 = text2;
					if (text3 != null)
					{
						uint num = <PrivateImplementationDetails>.ComputeStringHash(text3);
						if (num <= 1094710442U)
						{
							if (num <= 680835602U)
							{
								if (num != 101939353U)
								{
									if (num == 680835602U)
									{
										if (text3 == "user_already_exists")
										{
											MessageBox.Show("User already exists", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											return false;
										}
									}
								}
								else if (text3 == "email_already_exists")
								{
									MessageBox.Show("Email already exists", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									return false;
								}
							}
							else if (num != 979353360U)
							{
								if (num == 1094710442U)
								{
									if (text3 == "used_token")
									{
										MessageBox.Show("Already used token", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										return false;
									}
								}
							}
							else if (text3 == "success")
							{
								MessageBox.Show("Success!!", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								return true;
							}
						}
						else if (num <= 3041788540U)
						{
							if (num != 1913904611U)
							{
								if (num == 3041788540U)
								{
									if (text3 == "killswitch_is_enabled")
									{
										MessageBox.Show("The killswitch of the program is enabled, contact the developer", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										goto IL_3B3;
									}
								}
							}
							else if (text3 == "invalid_email_format")
							{
								MessageBox.Show("Invalid email format", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return false;
							}
						}
						else if (num != 4105418607U)
						{
							if (num == 4204349226U)
							{
								if (text3 == "invalid_token")
								{
									MessageBox.Show("Invalid token. Press ok if the token is correct.", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									return false;
								}
							}
						}
						else if (text3 == "maximum_users_reached")
						{
							MessageBox.Show("Maximum users of the program was reached, please contact the program owner", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return false;
						}
					}
					MessageBox.Show("Invalid API/Encryption key or the session expired", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				IL_3B3:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
				return false;
			}
			return false;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00018138 File Offset: 0x00016338
		public static bool c_activate(string c_username, string c_password, string c_token)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					webClient.Headers["User-Agent"] = c_api.user_agent;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(c_encryption.pin_public_key);
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["username"] = c_encryption.encrypt(c_username, c_api.enc_key, c_api.iv_key);
					nameValueCollection["password"] = c_encryption.encrypt(c_password, c_api.enc_key, c_api.iv_key);
					nameValueCollection["token"] = c_encryption.encrypt(c_token, c_api.enc_key, c_api.iv_key);
					nameValueCollection["sessid"] = c_encryption.byte_arr_to_str(Encoding.UTF8.GetBytes(c_api.session_id));
					NameValueCollection data = nameValueCollection;
					string text = c_encryption.decrypt(Encoding.UTF8.GetString(webClient.UploadValues(c_api.api_link + "handler.php?type=activate", data)), c_api.enc_key, c_api.iv_key);
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
					string text2 = text;
					string text3 = text2;
					if (text3 != null)
					{
						uint num = <PrivateImplementationDetails>.ComputeStringHash(text3);
						if (num <= 1090128640U)
						{
							if (num != 315331473U)
							{
								if (num != 979353360U)
								{
									if (num == 1090128640U)
									{
										if (text3 == "user_is_banned")
										{
											MessageBox.Show("The user is banned", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											return false;
										}
									}
								}
								else if (text3 == "success")
								{
									MessageBox.Show("Success!!", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									return true;
								}
							}
							else if (text3 == "invalid_username")
							{
								MessageBox.Show("Invalid username", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return false;
							}
						}
						else if (num <= 1655430144U)
						{
							if (num != 1094710442U)
							{
								if (num == 1655430144U)
								{
									if (text3 == "invalid_password")
									{
										MessageBox.Show("Invalid password", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										return false;
									}
								}
							}
							else if (text3 == "used_token")
							{
								MessageBox.Show("Already used token", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return false;
							}
						}
						else if (num != 3041788540U)
						{
							if (num == 4204349226U)
							{
								if (text3 == "invalid_token")
								{
									MessageBox.Show("Invalid token", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									return false;
								}
							}
						}
						else if (text3 == "killswitch_is_enabled")
						{
							MessageBox.Show("The killswitch of the program is enabled, contact the developer", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							goto IL_306;
						}
					}
					MessageBox.Show("Invalid API/Encryption key or the session expired", "AtomicProtector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				IL_306:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
				return false;
			}
			return false;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000184A8 File Offset: 0x000166A8
		public static bool c_all_in_one(string c_token, string c_hwid = "default")
		{
			bool flag = c_hwid == "default";
			if (flag)
			{
				c_hwid = WindowsIdentity.GetCurrent().User.Value;
			}
			bool flag2 = c_api.c_login(c_token, c_token, c_hwid);
			bool result;
			if (flag2)
			{
				result = true;
			}
			else
			{
				bool flag3 = c_api.c_register(c_token, c_token + "@email.com", c_token, c_token, c_hwid);
				if (flag3)
				{
					Environment.Exit(0);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000249C File Offset: 0x0000069C
		// (set) Token: 0x0600012D RID: 301 RVA: 0x000024A3 File Offset: 0x000006A3
		private static string stored_pass { get; set; }

		// Token: 0x0600012E RID: 302 RVA: 0x00018510 File Offset: 0x00016710
		public static string c_var(string c_var_name, string c_hwid = "default")
		{
			bool flag = c_hwid == "default";
			if (flag)
			{
				c_hwid = WindowsIdentity.GetCurrent().User.Value;
			}
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					webClient.Headers["User-Agent"] = c_api.user_agent;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(c_encryption.pin_public_key);
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["var_name"] = c_encryption.encrypt(c_var_name, c_api.enc_key, c_api.iv_key);
					nameValueCollection["username"] = c_encryption.encrypt(c_userdata.username, c_api.enc_key, c_api.iv_key);
					nameValueCollection["password"] = c_api.stored_pass;
					nameValueCollection["hwid"] = c_encryption.encrypt(c_hwid, c_api.enc_key, c_api.iv_key);
					nameValueCollection["sessid"] = c_encryption.byte_arr_to_str(Encoding.UTF8.GetBytes(c_api.session_id));
					NameValueCollection data = nameValueCollection;
					string text = c_encryption.decrypt(Encoding.UTF8.GetString(webClient.UploadValues(c_api.api_link + "handler.php?type=var", data)), c_api.enc_key, c_api.iv_key);
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
					result = text;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
				result = "";
			}
			return result;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000186D0 File Offset: 0x000168D0
		public static void c_log(string c_message)
		{
			bool flag = c_userdata.username == null;
			if (flag)
			{
				c_userdata.username = "NONE";
			}
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					webClient.Headers["User-Agent"] = c_api.user_agent;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(c_encryption.pin_public_key);
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection["username"] = c_encryption.encrypt(c_userdata.username, c_api.enc_key, c_api.iv_key);
					nameValueCollection["message"] = c_encryption.encrypt(c_message, c_api.enc_key, c_api.iv_key);
					nameValueCollection["sessid"] = c_encryption.byte_arr_to_str(Encoding.UTF8.GetBytes(c_api.session_id));
					NameValueCollection data = nameValueCollection;
					string @string = Encoding.UTF8.GetString(webClient.UploadValues(c_api.api_link + "handler.php?type=log", data));
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
			}
		}

		// Token: 0x040000A9 RID: 169
		private static string api_link = "https://cauth.me/api/";

		// Token: 0x040000AA RID: 170
		private static string user_agent = "Mozilla cAuth";
	}
}
