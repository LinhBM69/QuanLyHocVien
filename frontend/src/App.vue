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
onBeforeMount(() => {
  if (!localStorage.getItem("token")) {
    router.push('/dangnhap')
  }
})
</script>
