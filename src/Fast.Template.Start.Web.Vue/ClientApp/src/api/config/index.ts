import { AxiosPromise } from "axios";
import { IKeyValue } from "/@/types/base/kv";
import request from "/@/utils/request";

export function getStandardClaims(): AxiosPromise<string[]> {
    return request({
        url: '/api/IdsAdmin/config/standard-claims',
        method: 'get'
    });
}

export function getSecretTypes(): AxiosPromise<string[]> {
    return request({
        url: '/api/IdsAdmin/config/secret-types',
        method: 'get'
    });
}
/**
 * 签名算法列表
 * @returns 
 */
export function getSigningAlgorithms(): AxiosPromise<string[]> {
    return request({
        url: '/api/IdsAdmin/config/signing-algorithms',
        method: 'get'
    });
}

/**
 * 授权类型
 * @returns 
 */
export function getGrantTypes(): AxiosPromise<string[]> {
    return request({
        url: '/api/IdsAdmin/config/grant-types',
        method: 'get'
    });
}

export function getScopes(): AxiosPromise<string[]> {
    return request({
        url: '/api/IdsAdmin/config/scopes',
        method: 'get'
    });
}

export function getHashTypes(): AxiosPromise<IKeyValue[]> {
    return request({
        url: '/api/IdsAdmin/config/hash-types',
        method: 'get'
    });
}

/**
 * 访问令牌类型
 * @returns 
 */
export function getAccessTokenTypes(): AxiosPromise<IKeyValue[]> {
    return request({
        url: '/api/IdsAdmin/config/access-token-types',
        method: 'get'
    });
}

/**
 * 刷新令牌使用情况
 * @returns 
 */
export function getTokenUsages(): AxiosPromise<IKeyValue[]> {
    return request({
        url: '/api/IdsAdmin/config/token-usages',
        method: 'get'
    });
}

/**
 * 刷新令牌过期
 * @returns 
 */
export function getTokenExpirations(): AxiosPromise<IKeyValue[]> {
    return request({
        url: '/api/IdsAdmin/config/token-expirations',
        method: 'get'
    });
}