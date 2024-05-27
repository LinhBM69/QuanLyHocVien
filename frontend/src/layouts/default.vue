<template>
  <v-app>
    <v-navigation-drawer v-if="checkKhoaHoc">
      <v-list>
        <v-list-item v-for="(item, index) in khoaHoc" :key="index" :title="item.title" @click="onMenuClick(index)" />
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <router-view />
    </v-main>

    <AppFooter />
  </v-app>
</template>

<script lang="ts" setup>
import { onBeforeMount, ref } from 'vue';
import { useRouter } from 'vue-router';

//
const router = useRouter()
const khoaHoc = ref([
  { value: 0, title: 'Tài khoản', router: 'taikhoan' },
  { value: 1, title: 'Phân quyền', router: 'phanquyen' },
  { value: 2, title: 'Tài khoản phân quyền', router: 'taiKhoanPhanQuyen' },
  { value: 3, title: 'Khóa học', router: 'khoahoc' }
])
const checkKhoaHoc = ref(false)
const interval = ref()

const isKhoaHoc = () => {

  if (localStorage.getItem('token')) return checkKhoaHoc.value = true
  return checkKhoaHoc.value = false
}

onBeforeMount(() => {
  interval.value = setInterval(isKhoaHoc, 1000)
})

const onMenuClick = (index) => {
  const temp = khoaHoc.value.filter(e => e.value === index)
  router.push(`/${temp[0].router}`)
}


</script>

<style scoped>
:deep(.v-list-item:hover) {
  cursor: pointer;
  background-color: gray;
}
</style>
