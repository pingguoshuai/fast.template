import { authConfigurationDto } from "./models/authConfiguration";
import { UserInfoState, currentUserDto } from "./models/currentUserDto";

export interface applicationConfigurationDto {
    auth: authConfigurationDto;
    currentUser: currentUserDto;
}

export interface appConfigState {
    appConfig: applicationConfigurationDto;
    userInfos: UserInfoState;
}