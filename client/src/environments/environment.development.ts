
export const environment = {
  production: false,
  msalConfig: {
    auth: {
      clientId: '2262a26d-a535-497b-bc1a-71fa0e02eb7a',
      authority: 'https://login.microsoftonline.com/eaf5f3e6-4de8-4ab1-bf60-c9d7ecc5109e',
      redirectUri: `${window.location.origin}/home`,
      postLogoutRedirectUri: `${window.location.origin}/loggedOut`
    }
  },
  apiConfig: {
    scopes: ['user.read'],
    uri: 'https://graph.microsoft.com/v1.0/me',
    picUri: 'https://graph.microsoft.com/v1.0/me/photo/$value'
  }
};
