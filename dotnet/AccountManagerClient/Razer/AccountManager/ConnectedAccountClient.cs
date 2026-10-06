using System;
using System.Collections.Generic;
using Razer.AccountManager.ConnectedAccounts;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	public class ConnectedAccountClient
	{
		private AccountManagerClient m_host;

		private ClientPipeSocket Socket => m_host.Socket;

		public event EventHandler<ConnectCompletedEventArgs> ConnectComplete;

		public event EventHandler<DisconnectEventArgs> DisconnectComplete;

		internal ConnectedAccountClient(AccountManagerClient host)
		{
			m_host = host;
		}

		public void StartConnect(ConnectedAccount account, IEnumerable<string> permissions, bool reauthenticate)
		{
			EnsureConnected();
			new ConnectToAccountHandler(Socket).Execute(account, permissions, reauthenticate);
		}

		public void StartRefreshToken(ConnectedAccount account, string refreshToken)
		{
			EnsureConnected();
			new RefreshAccountTokenHandler(Socket).Execute(account, refreshToken);
		}

		public bool IsConnected(ConnectedAccount account)
		{
			EnsureConnected();
			return new IsConnectedHandler(Socket).Execute(account);
		}

		public void Disconnect(ConnectedAccount account)
		{
			EnsureConnected();
			new DisconnectFromAccountHandler(Socket).Execute(account);
		}

		public ConnectedAccountCredentials GetCredentials(ConnectedAccount account)
		{
			EnsureConnected();
			return new GetCredentialsHandler(Socket).Execute(account);
		}

		internal void OnConnectComplete(ConnectCompletedEventArgs args)
		{
			this.ConnectComplete?.Invoke(this, args);
		}

		internal void OnDisconnectComplete(DisconnectEventArgs args)
		{
			this.DisconnectComplete?.Invoke(this, args);
		}

		private void EnsureConnected()
		{
			m_host.EnsureConnected();
		}
	}
}
