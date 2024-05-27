<template>
  <div v-if="loading" class="d-flex flex-column ga-4 pa-4">
    <div class="text-end">
      <AddOrEdit ref="refForm" :btnTitle="'Thêm tài khoản'" :title="title" :form="form" @value="onValueChange"
        @addOrEdit="addOrEdit" />
    </div>
    <Table :headers="table.headers" :data="table.data" @value="onValueChange" />
  </div>
</template>

<script setup>
import { onBeforeMount } from 'vue';
import apiTaiKhoan from '../api/taiKhoan';
import Table from '@/components/Table.vue'
import AddOrEdit from '@/dialogs/AddOrEdit.vue';
import { Form } from '@/enum'

const loading = ref(false)

const table = ref({ headers: [], data: [] })
const form = ref([])
const refForm = ref()
const id = ref(0)
const title = ref('Thêm tài khoản')

onBeforeMount(async () => {
  loading.value = false

  table.value.headers = [
    { title: "ID", key: "column1" },
    { title: "EMAIL", key: "column2" },
    { title: "HỌ VÀ TÊN", key: "column3" },
    { title: "SỐ ĐIỆN THOẠI", key: "column4" },
    { title: "", key: "edit" }
  ]

  await fetchData()

  form.value = [
    { form: Form.textField, value: 'email', label: 'Email' },
    { form: Form.textField, value: 'hoVaTen', label: 'Họ và tên' },
    { form: Form.textField, value: 'soDienThoai', label: 'Số điện thoại' },
    { form: Form.textField, value: 'matKhau', label: 'Mật khẩu' }
  ]

  loading.value = true
})

const fetchData = async () => {
  loading.value = false
  table.value.data = await apiTaiKhoan.getAll({ pageSize: 10, pageNumber: 1 })
  console.log(table.value.data, 'table');
  table.value.data = table.value.data.data
  table.value.data = table.value.data.map(e => {
    return {
      column1: e.taiKhoanId,
      column2: e.email,
      column3: e.hoVaTen,
      column4: e.soDienThoai,
      column5: e.matKhau,
      edit: true
    }
  })
  loading.value = true
}

const addOrEdit = async (e) => {
  const temp = { taiKhoanId: id.value, email: null, hoVaTen: null, soDienThoai: null, matKhau: null }
  e.forEach(e => {
    if (e.email) temp.email = e.email
    if (e.hoVaTen) temp.hoVaTen = e.hoVaTen
    if (e.soDienThoai) temp.soDienThoai = e.soDienThoai
    if (e.matKhau) temp.matKhau = e.matKhau
  });

  if (id.value > 0) {
    await apiTaiKhoan.put(temp)
  } else {
    await apiTaiKhoan.post(temp)
  }
  await fetchData()
}

const onValueChange = (e) => {
  const temp = {
    taiKhoanId: e.column1,
    email: e.column2,
    hoVaTen: e.column3,
    soDienThoai: e.column4,
    matKhau: e.column5
  }

  id.value = temp.taiKhoanId
  title.value = id.value > 0 ? 'Sửa tài khoản' : 'Thêm tài khoản'
  refForm.value.show(temp)
}

</script>
