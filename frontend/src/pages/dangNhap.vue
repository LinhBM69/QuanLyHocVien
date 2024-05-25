<template>
  <DangNhap />
</template>

<script lang="ts" setup>
import { onBeforeMount } from 'vue';
import DangNhap from '../components/DangNhap.vue';
//
onBeforeMount(() => {
  localStorage.removeItem('token')
})
</script>
