<template>
  <v-app>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts" setup>
import { onBeforeMount } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter()
console.log('app');

onBeforeMount(() => {
  setTimeout(() => {
    if (!localStorage.getItem("token")) {
      router.push('/dangnhap')
    }
  }, 1000);
})
</script>
