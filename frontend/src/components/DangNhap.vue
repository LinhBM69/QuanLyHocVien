<template>
  <v-container class="fill-height">
    <v-sheet class="mx-auto" width="300">

      <v-form ref="form">
        <v-text-field v-model="name" :rules="nameRules" label="Name" required></v-text-field>

        <v-text-field v-model="pass" :rules="nameRules" label="Pass" required></v-text-field>


        <v-checkbox v-model="checkbox" :rules="[v => !!v || 'You must agree to continue!']" label="Do you agree?"
          required></v-checkbox>

        <div class="d-flex flex-column">
          <v-btn class="mt-4" color="success" block @click="dangnhap">
            Đăng nhập
          </v-btn>

          <v-btn class="mt-4" color="warning" block>
            Đăng ký
          </v-btn>

          <v-btn class="mt-4" color="error" block>
            Quên Mật khẩu
          </v-btn>
        </div>
      </v-form>
    </v-sheet>
  </v-container>
</template>

<script setup>
import { ref } from 'vue';
import taikhoan from '../api/taiKhoan';
import { useRouter } from 'vue-router';

const router = useRouter()
const checkbox = ref(false)
const name = ref()
const nameRules = ref([
  v => !!v || 'Cần nhập thông tin',
  v => (v && v.length > 0) || 'Tên phải nhiều hơn một ký tự',
])
const pass = ref()

const dangnhap = async () => {
  const user = await taikhoan.get({email: name.value, matKhau: pass.value, hoVaTen: "null"})
  if(user.data){
    localStorage.setItem("token", true);
    localStorage.setItem("taiKhoanId", user.data.taiKhoanId)
    router.push('/khoahoc/danhSachKhoaHoc')
  }
}
</script>
