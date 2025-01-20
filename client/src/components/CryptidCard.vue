<script setup>
import { Cryptid } from '@/models/Cryptid.js';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <div class="cryptid-card text-light fs-4  mb-5" :style="{ backgroundImage: `url(${cryptid.imgUrl})` }">
    <div class="h-100 w-100 d-flex align-items-end p-3">

      <div>
        <span>{{ cryptid.displayId }}</span>
        <hr>
        <p>{{ cryptid.name }}</p>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.cryptid-card {
  min-height: 50dvh;
  background-size: cover;
}

.h-100 {
  min-height: 50dvh;
  backdrop-filter: blur(3px);
}

* {
  text-shadow: 1px 1px black;
  font-weight: bold;
}
</style>