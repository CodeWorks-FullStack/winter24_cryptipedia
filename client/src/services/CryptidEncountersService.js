import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class CryptidEncountersService {
  async getCryptidEncounterProfilesByCryptidId(cryptid) {
    const response = await api.get(`api/cryptids/${cryptid}/cryptidEncounters`)
    logger.log('GOT CRYPTID ENCOUNTERS', response.data)
  }
}

export const cryptidEncountersService = new CryptidEncountersService()