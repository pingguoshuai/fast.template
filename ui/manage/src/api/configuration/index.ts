
import { AxiosPromise } from 'axios';
import request from '/@/utils/request';
import { applicationConfigurationDto } from './model';

export const appConfigurationService = {
    getAsync: (includeLocalizationResources: boolean): AxiosPromise<applicationConfigurationDto> => {
        return request({
            url: `/api/abp/application-configuration?IncludeLocalizationResources=${includeLocalizationResources}`,
            method: 'get'
        });
    }
}