import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { CryptidEncounterProfile } from "@/models/CryptidEncounterProfile.js"
import { AppState } from "@/AppState.js"

class CryptidEncountersService {
  async createCryptidEncounter(cryptidEncounterData) {
    const response = await api.post('api/cryptidEncounters', cryptidEncounterData)
    logger.log('CREATED CRYPTID ENCOUNTER', response.data)
    const profile = new CryptidEncounterProfile(response.data)
    AppState.cryptidEncounterProfiles.push(profile)
    AppState.activeCryptid.encounterCount++
  }

  async getCryptidEncounterProfilesByCryptidId(cryptidId) {
    AppState.cryptidEncounterProfiles = [] // 👻🚫
    const response = await api.get(`api/cryptids/${cryptidId}/cryptidEncounters`)
    logger.log('GOT CRYPTID ENCOUNTERS', response.data)
    const profiles = response.data.map(pojo => new CryptidEncounterProfile(pojo))
    AppState.cryptidEncounterProfiles = profiles
  }
}

export const cryptidEncountersService = new CryptidEncountersService()