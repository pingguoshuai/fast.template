import { defineStore } from "pinia";
import { appConfigState } from "../api/configuration/model";
import { Session } from "../utils/storage";
import { appConfigurationService } from "../api/configuration";
import { UserInfoState } from "../api/configuration/models/currentUserDto";

