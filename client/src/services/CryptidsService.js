import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Cryptid } from "@/models/Cryptid.js"
import { AppState } from "@/AppState.js"

class CryptidsService {
  async getCryptidById(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}`)
    logger.log('GOT CRYPTID 👽', response.data)
  }
  async getCryptids() {
    const response = await api.get('api/cryptids')
    logger.log('GOT CRYPTIDS 👽👽👽', response.data)
    const cryptids = response.data.map(cryptidPOJO => new Cryptid(cryptidPOJO))
    AppState.cryptids = cryptids
  }
}

export const cryptidsService = new CryptidsService()