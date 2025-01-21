import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Cryptid } from "@/models/Cryptid.js"
import { AppState } from "@/AppState.js"
import App from "@/App.vue"

class CryptidsService {
  async getCryptidById(cryptidId) {
    AppState.activeCryptid = null // 👻🚫
    const response = await api.get(`api/cryptids/${cryptidId}`)
    logger.log('GOT CRYPTID 👽', response.data)
    const cryptid = new Cryptid(response.data)
    AppState.activeCryptid = cryptid
  }
  async getCryptids() {
    const response = await api.get('api/cryptids')
    logger.log('GOT CRYPTIDS 👽👽👽', response.data)
    const cryptids = response.data.map(cryptidPOJO => new Cryptid(cryptidPOJO))
    AppState.cryptids = cryptids
  }
}

export const cryptidsService = new CryptidsService()