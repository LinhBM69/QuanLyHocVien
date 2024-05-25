<template>
  <v-app>
    <v-navigation-drawer v-if="checkKhoaHoc">
      <v-list>
        <v-list-item v-for="(item, index) in khoaHoc" :key="index" :title="item.title" @click="onKhoaHocClick(index)" />
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
  { value: 0, title: 'Danh sách khóa học', router: 'danhSachKhoaHoc' },
  { value: 1, title: 'Thêm khóa học', router: 'themKhoaHoc' },
  { value: 2, title: 'Sửa khóa học', router: 'suaKhoaHoc' },
  { value: 3, title: 'Xóa khóa học', router: 'xoaKhoaHoc' }
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

const onKhoaHocClick = (index) => {
  const temp = khoaHoc.value.filter(e => e.value === index)
  router.push(`/khoahoc/${temp[0].router}`)
}


</script>

<style scoped>
:deep(.v-list-item:hover) {
  cursor: pointer;
  background-color: gray;
}
</style>
