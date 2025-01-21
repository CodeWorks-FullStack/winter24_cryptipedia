<script setup>
import { AppState } from '@/AppState.js';
import { cryptidEncountersService } from '@/services/CryptidEncountersService.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';


const cryptid = computed(() => AppState.activeCryptid)
const profiles = computed(() => AppState.cryptidEncounterProfiles)
const account = computed(() => AppState.account)
const hasEncountered = computed(() => profiles.value.some(profile => profile.id == account.value?.id))

const route = useRoute()

onMounted(() => {
  getCryptidById()
  getCryptidEncounterProfilesByCryptidId()
})

async function getCryptidById() {
  try {
    const cryptidId = route.params.cryptidId
    await cryptidsService.getCryptidById(cryptidId)
  } catch (error) {
    Pop.meow(error)
    logger.error('[GETTING CRYPTID BY ID]', error.message)
  }
}

async function getCryptidEncounterProfilesByCryptidId() {
  try {
    const cryptidId = route.params.cryptidId
    await cryptidEncountersService.getCryptidEncounterProfilesByCryptidId(cryptidId)
  } catch (error) {
    Pop.meow(error)
    logger.error('[GETTING CRYPTID PROFILES]', error.message)
  }
}

async function createCryptidEncounter() {
  try {
    const cryptidEncounterData = { cryptidId: route.params.cryptidId }
    await cryptidEncountersService.createCryptidEncounter(cryptidEncounterData)
  } catch (error) {
    Pop.meow(error)
    logger.error('[CREATE ENCOUNTER]', error.message)
  }
}
</script>


<template>
  <div v-if="cryptid" class="container-fluid bg-dark">
    <section class="row text-light">
      <div class="col-md-8">
        <div class="p-3">
          <span class="text-warning italiana-font sub-header text-capitalize">
            {{ cryptid.origin }} Cryptid
          </span>
          <h1 class="italiana-font">{{ cryptid.name.toUpperCase() }}</h1>
          <p>{{ cryptid.description }}</p>
          <h2 class="italiana-font" :title="`Threat Level ${cryptid.threatLevel}/10`">
            <span class="d-block">
              Threat Level:
            </span>
            <i v-for="number in cryptid.threatLevel" :key="'threat' + number" class="mdi mdi-circle"></i>
            <i v-for="number in 10 - cryptid.threatLevel" :key="'remaining threat' + number"
              class="mdi mdi-circle-outline"></i>
          </h2>
          <h2 class="italiana-font mb-4" :title="`Size: ${cryptid.size}/10`">
            <span class="d-block">
              Size:

            </span>
            <i v-for="number in cryptid.size" :key="'size' + number" class="mdi mdi-circle"></i>
            <i v-for="number in 10 - cryptid.size" :key="'remaining size' + number" class="mdi mdi-circle-outline"></i>
          </h2>
          <button v-if="account" :disabled="hasEncountered" @click="createCryptidEncounter()"
            class="btn btn-warning mb-2">
            I've encountered the {{ cryptid.name }}
          </button>
          <div v-if="profiles.length > 0">
            <h3 class="text-warning italiana-font">Encountered By {{ cryptid.encounterCount }} humans</h3>
            <div class="d-flex gap-2 flex-wrap">
              <img v-for="profile in profiles" :key="profile.cryptidEncounterId" :src="profile.picture"
                :alt="'picture of ' + profile.name" :title="profile.name" class="profile-picture">
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-4 px-md-0">
        <img :src="cryptid.imgUrl" :alt="'A picture of ' + cryptid.name" class="cryptid-img">
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.cryptid-img {
  width: 100%;
  height: 100dvh;
  object-fit: cover;
}

h1 {
  font-size: 5rem;
}

.sub-header {
  font-size: 3rem;
}

.profile-picture {
  height: 10dvh;
  aspect-ratio: 1/1;
  border-radius: 50%;
  object-fit: cover;
}
</style>