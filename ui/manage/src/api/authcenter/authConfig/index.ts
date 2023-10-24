import { AxiosPromise } from "axios";
import request from "/@/utils/request";
import { IKeyValue } from "/@/types/base/keyvalue";

export class authConfigService {
    getStandardClaims(): AxiosPromise<string[]> {
        return request({
            url: '/api/IdsAdmin/config/standard-claims',
            method: 'get'
        });
    }

    getSecretTypes(): AxiosPromise<string[]> {
        return request({
            url: '/api/IdsAdmin/config/secret-types',
            method: 'get'
        });
    }

    getSigningAlgorithms(): AxiosPromise<string[]> {
        return request({
            url: '/api/IdsAdmin/config/signing-algorithms',
            method: 'get'
        });
    }

    getGrantTypes(): AxiosPromise<string[]> {
        return request({
            url: '/api/IdsAdmin/config/grant-types',
            method: 'get'
        });
    }

    getScopes(): AxiosPromise<string[]> {
        return request({
            url: '/api/IdsAdmin/config/scopes',
            method: 'get'
        });
    }

    getHashTypes(): AxiosPromise<IKeyValue[]> {
        return request({
            url: '/api/IdsAdmin/config/hash-types',
            method: 'get'
        });
    }
    /**
     * 访问令牌类型
     * @returns 
     */
    getAccessTokenTypes(): AxiosPromise<IKeyValue[]> {
        return request({
            url: '/api/IdsAdmin/config/access-token-types',
            method: 'get'
        });
    }

    /**
     * 刷新令牌使用情况
     * @returns 
     */
    getTokenUsages(): AxiosPromise<IKeyValue[]> {
        return request({
            url: '/api/IdsAdmin/config/token-usages',
            method: 'get'
        });
    }

    /**
     * 刷新令牌过期
     * @returns 
     */
    getTokenExpirations(): AxiosPromise<IKeyValue[]> {
        return request({
            url: '/api/IdsAdmin/config/token-expirations',
            method: 'get'
        });
    }
}

export default new authConfigService();