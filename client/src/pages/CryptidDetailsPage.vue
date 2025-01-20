<script setup>
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

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
  <h1>Cryptid details page</h1>
</template>


<style lang="scss" scoped></style>