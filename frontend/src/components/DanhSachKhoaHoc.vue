<template>
  <v-table class="pa-4">
    <thead>
      <tr>
        <th v-for="(item, index) in headers" :key="index">
          {{ item.title }}
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in desserts" :key="item.name">
        <td>{{ item.khoaHocId }}</td>
        <td>{{ item.tenKhoaHoc }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup>
import { onBeforeMount } from 'vue';
import khoaHoc from '../api/khoaHoc';


const headers = [
  { title: "ID", key: "khoaHocId", sortable: false },
  { title: "TÊN KHÓA HỌC", key: "tenKhoaHoc", sortable: true }
];

const desserts = ref([])

onBeforeMount(async () => {
  const res = await khoaHoc.getAll({ pageSize: 10, pageNumber: 1 })
  desserts.value = res.data.data
})

</script>
