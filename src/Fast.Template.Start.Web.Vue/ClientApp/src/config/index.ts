interface IApiConfig {
    AuthUrl: string;
    BaseUrl: string;
    AccountUrl: string;
}

function getConfig(): IApiConfig {
    const { VITE_AUTH_URL, VITE_BASE_URL, VITE_ACCOUNT_URL } = import.meta.env;
    return {
        AuthUrl: VITE_AUTH_URL,
        BaseUrl: VITE_BASE_URL,
        AccountUrl: VITE_ACCOUNT_URL
    } as IApiConfig;
}

export const apiConfig = getConfig();