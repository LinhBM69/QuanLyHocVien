<template>
  <v-table>
    <thead>
      <tr>
        <th v-for="(item, index) in table.headers" :key="index">
          {{ item.title }}
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in table.data" :key="item.name">
        <td v-if="item.column1">{{ item.column1 }}</td>
        <td v-if="item.column2">{{ item.column2 }}</td>
        <td v-if="item.column4">{{ item.column4 }}</td>
        <td v-if="item.column5">{{ item.column5 }}</td>
        <td v-if="item.column6">{{ item.column6 }}</td>
        <td v-if="item.column7">{{ item.column7 }}</td>
        <td v-if="item.column8">{{ item.column8 }}</td>
        <td v-if="item.column9">{{ item.column9 }}</td>
        <td v-if="item.edit" class="d-flex ga-2 align-center justify-end">
          <v-btn class="text-none font-weight-regular" prepend-icon="mdi-account" variant="tonal"
            @click="edit(item)">
            Edit
          </v-btn>
          <v-btn class="text-none font-weight-regular" prepend-icon="mdi-account" variant="tonal"
            @click="edit(item)">
            delete
          </v-btn>
        </td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup>
import { onBeforeMount, ref } from 'vue';


const table = ref({ headers: [], data: [] })

const props = defineProps(['headers', 'data'])
const emits = defineEmits(['value'])

onBeforeMount(() => {
  table.value.headers = props.headers
  table.value.data = props.data
  console.log(table.value.data, '888');
})

const edit = (e) => {
  emits('value', e)
}

</script>
<style scoped></style>
