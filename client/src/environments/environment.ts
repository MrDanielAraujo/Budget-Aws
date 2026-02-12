export const environment = {
  production: true,
  msalConfig: {
    auth: {
      clientId: 'b03554b3-fd52-4221-a1cd-b0e1dae361c7',
      authority: 'https://login.microsoftonline.com/802762d2-02c4-4677-98ba-54060a234204',
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
