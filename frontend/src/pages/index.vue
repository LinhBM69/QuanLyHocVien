<template>
<div></div>
</template>

<script lang="ts" setup>
import { onBeforeMount } from 'vue';
import DangNhap from '../components/DangNhap.vue';
import { useRouter } from 'vue-router';

const router = useRouter()

onBeforeMount(() => {
  if(!localStorage.getItem("token")){
    router.push('/dangnhap')
  }
})

</script>
