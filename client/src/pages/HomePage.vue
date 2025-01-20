<script setup>
import { AppState } from '@/AppState.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const cryptids = computed(() => AppState.cryptids)

onMounted(() => {
  getCryptids()
})

async function getCryptids() {
  try {
    await cryptidsService.getCryptids()
  } catch (error) {
    Pop.meow(error)
    logger.error("[GETTING CRYPTIDS]", error.message)
  }
}

</script>

<template>
  <div class="container-fluid forest-bg">
    <section class="row shadow-layer">
      <div class="col-md-7 align-self-center">
        <div class="p-5 text-light">
          <h1>Terrestrials</h1>
          <p>
            A terrestrial cryptid is a creature that exists on land but has not been “scientifically” proven. These
            creatures often stem from folklore, mythology, or anecdotal evidence. Unlike aquatic cryptids, like the Loch
            Ness Monster, terrestrial cryptids inhabit forests, mountains, or other land-based environments.
          </p>
        </div>
      </div>
      <div class="col-md-5 align-self-end">
        <img src="/public/img/cryptid_cat.png" alt="Cryptid cat" class="img-fluid">
      </div>
    </section>
  </div>

  <div class="container-fluid">
    <section class="row justify-content-center">
      <div class="col-10">
        <header class="italiana-font cryptids-header">
          <span class="bg-text">CRYPTIDS</span>
          <h2>CRYPTIDS</h2>
        </header>
      </div>
      <div class="col-10">
        <div class="row">
          <div v-for="cryptid in cryptids" :key="cryptid.id" class="col-md-3">
            {{ cryptid.name }}
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss">
.forest-bg {
  background-image: url(https://images.unsplash.com/photo-1446553009413-64b9505cacb0?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-size: cover;
}

.shadow-layer {
  backdrop-filter: blur(2px);
  background-color: rgba(0, 0, 0, 0.825);


  h1,
  p {
    text-shadow: 1px 1px black;
  }

  img {
    filter: hue-rotate(-100deg);
  }

}

.bg-text {
  font-size: 8rem;
  color: var(--bs-warning);
}

.cryptids-header {
  position: relative;

  span {
    user-select: none;
  }
}

h2 {
  font-size: 4rem;
  position: absolute;
  top: 3.5rem;
}
</style>
