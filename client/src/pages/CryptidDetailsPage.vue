<script setup>
import { AppState } from '@/AppState.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';


const cryptid = computed(() => AppState.activeCryptid)

const route = useRoute()

onMounted(() => {
  getCryptidById()
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
          <h2 class="italiana-font" :title="'Threat Level ' + cryptid.threatLevel">
            <span class="d-block">
              Threat Level:
            </span>
            <i v-for="number in cryptid.threatLevel" :key="'threat' + number" class="mdi mdi-circle"></i>
            <i v-for="number in 10 - cryptid.threatLevel" :key="'remaining threat' + number"
              class="mdi mdi-circle-outline"></i>
          </h2>
          <h2 class="italiana-font" :title="'Size ' + cryptid.threatLevel">
            <span class="d-block">
              Size:

            </span>
            <i v-for="number in cryptid.size" :key="'size' + number" class="mdi mdi-circle"></i>
            <i v-for="number in 10 - cryptid.size" :key="'remaining size' + number" class="mdi mdi-circle-outline"></i>
          </h2>
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
</style>