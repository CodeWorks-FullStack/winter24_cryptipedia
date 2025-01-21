import { Profile } from "./Profile.js"

export class Cryptid {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.name = data.name
    this.description = data.description
    this.imgUrl = data.imgUrl
    this.threatLevel = data.threatLevel
    this.origin = data.origin
    this.size = data.size
    this.discovererId = data.discovererId
    this.discoverer = new Profile(data.discoverer)
  }

  get displayId() {
    return this.id < 10 ? '0' + this.id : this.id
  }
}