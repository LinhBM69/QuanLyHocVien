<template>
  <div v-if="loading" class="d-flex flex-column ga-4 pa-4">
    <div class="text-end">
      <AddOrEdit ref="refForm" :btnTitle="'Thêm quyền'" :title="title" :form="form" @value="onValueChange" @addOrEdit="addOrEdit" />
    </div>
    <Table :headers="table.headers" :data="table.data" @value="onValueChange" />
  </div>
</template>

<script setup>
import { onBeforeMount } from 'vue';
import apiPhanQuyen from '../api/phanQuyen';
import Table from '@/components/Table.vue'
import AddOrEdit from '@/dialogs/AddOrEdit.vue';
import { Form } from '@/enum'

const loading = ref(false)

const table = ref({ headers: [], data: [] })
const form = ref([])
const refForm = ref()
const id = ref(0)
const title = ref('Thêm quyền')

onBeforeMount(async () => {
  loading.value = false

  table.value.headers = [
    { title: "ID", key: "column1" },
    { title: "TÊN QUYỀN", key: "column2" },
    { title: "", key: "edit" }
  ]

  initForm()

  await fetchData()

  loading.value = true
})

const initForm = () => {
  form.value = [
    { form: Form.textField, value: 'tenQuyen', label: 'Tên quyền' }
  ]
}

const fetchData = async () => {
  loading.value = false
  table.value.data = await apiPhanQuyen.getAll({ pageSize: 10, pageNumber: 1 })
  console.log(table.value.data,8888);
  table.value.data = table.value.data.data
  table.value.data = table.value.data.map(e => {
    return {
      column1: e.phanQuyenId,
      column2: e.tenQuyen,
      edit: true
    }
  })

  initForm()
  loading.value = true
}

const addOrEdit = async (e) => {

  if (id.value > 0) {
    await apiPhanQuyen.put({ phanQuyenId: id.value, tenQuyen: e[0].tenQuyen })
  } else {
    await apiPhanQuyen.post({ tenQuyen: e[0].tenQuyen })
  }
  await fetchData()
}

const onValueChange = (e) => {
  const temp = {
    phanQuyenId: e.column1,
    tenQuyen: e.column2
  }

  id.value = temp.phanQuyenId

  title.value = id.value > 0 ? 'Sửa quyền' : 'Thêm quyền'
  refForm.value.show(temp)
}

</script>
