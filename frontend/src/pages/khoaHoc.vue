<template>
  <div v-if="loading" class="d-flex flex-column ga-4 pa-4">
    <div class="text-end">
      <AddOrEdit ref="refForm" :btnTitle="'Thêm khóa học'" :title="title" :form="form" @value="onValueChange" @addOrEdit="addOrEdit" />
    </div>
    <Table :headers="table.headers" :data="table.data" @value="onValueChange" />
  </div>
</template>

<script setup>
import { onBeforeMount } from 'vue';
import apiKhoaHoc from '../api/khoaHoc';
import Table from '@/components/Table.vue'
import AddOrEdit from '@/dialogs/AddOrEdit.vue';
import { Form } from '@/enum'

const loading = ref(false)

const table = ref({ headers: [], data: [] })
const form = ref([])
const refForm = ref()
const id = ref(0)
const title = ref('Thêm khóa học')

onBeforeMount(async () => {
  loading.value = false

  table.value.headers = [
    { title: "ID", key: "column1" },
    { title: "TÊN KHÓA HỌC", key: "column2" },
    { title: "", key: "edit" }
  ]

  initForm()

  await fetchData()

  loading.value = true
})

const initForm = () => {
  form.value = [
    { form: Form.textField, value: 'tenKhoaHoc', label: 'Tên khóa học' }
  ]
}

const fetchData = async () => {
  loading.value = false
  table.value.data = await apiKhoaHoc.getAll({ pageSize: 10, pageNumber: 1 })
  table.value.data = table.value.data.data.data
  table.value.data = table.value.data.map(e => {
    return {
      column1: e.khoaHocId,
      column2: e.tenKhoaHoc,
      edit: true
    }
  })

  initForm()
  loading.value = true
}

const addOrEdit = async (e) => {

  if (id.value > 0) {
    await apiKhoaHoc.put({ khoaHocId: id.value, tenKhoaHoc: e[0].tenKhoaHoc })
  } else {
    await apiKhoaHoc.post({ tenKhoaHoc: e[0].tenKhoaHoc })
  }
  await fetchData()
}

const onValueChange = (e) => {
  const temp = {
    khoaHocId: e.column1,
    tenKhoaHoc: e.column2
  }

  id.value = temp.khoaHocId

  title.value = id.value > 0 ? 'Sửa khóa học' : 'Thêm khóa học'
  refForm.value.show(temp)
}

</script>
