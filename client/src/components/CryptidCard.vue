<script setup>
import { Cryptid } from '@/models/Cryptid.js';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <p>{{ cryptid.name }}</p>
</template>


<style lang="scss" scoped></style>