<script setup>
import { Cryptid } from '@/models/Cryptid.js';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <RouterLink :to="{ name: 'CryptidDetails', params: { cryptidId: cryptid.id } }">
    <div class="cryptid-card text-light fs-4  mb-5" :style="{ backgroundImage: `url(${cryptid.imgUrl})` }">
      <div class="inner-card d-flex flex-column justify-content-between p-3">
        <div class="text-end">
          <span title="Encountered by 0 humans">
            <i class="mdi mdi-ufo-outline me-1"></i>
            <span>0</span>
          </span>
        </div>
        <div>
          <span>{{ cryptid.displayId }}</span>
          <hr>
          <p>{{ cryptid.name }}</p>
        </div>
      </div>
    </div>
  </RouterLink>
</template>


<style lang="scss" scoped>
.cryptid-card {
  min-height: 50dvh;
  background-size: cover;
}

.inner-card {
  min-height: 50dvh;
  width: 100%;
  backdrop-filter: blur(3px);
}

* {
  text-shadow: 1px 1px black;
  font-weight: bold;
}
</style>