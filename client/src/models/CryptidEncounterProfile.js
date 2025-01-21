import { Profile } from "./Profile.js";

export class CryptidEncounterProfile extends Profile {
  constructor(data) {
    super(data)

    this.cryptidId = data.cryptidId
    this.cryptidEncounterId = data.cryptidEncounterId
  }
}
