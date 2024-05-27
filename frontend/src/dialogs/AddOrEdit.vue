<template>
  <div>
    <v-btn class="text-none font-weight-regular" prepend-icon="mdi-account" :text="props.btnTitle" variant="tonal"
      @click="$emit('value', { column1: -1 })" />
    <v-dialog v-model="hide" max-width="600">
      <v-card prepend-icon="mdi-account" :title="props.title">
        <v-card-text>
          <div v-for="(e, index) in data" :key="index" class="d-block">
            {{ e[e.value] }}
            <v-text-field v-if="e.form === Form.textField" :label="e.label" v-model="e[e.value]" />
          </div>
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn text="Close" variant="plain" @click="hide = false"></v-btn>

          <v-btn color="primary" text="Save" variant="tonal" @click="save"></v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue';
import { Form } from '@/enum'

const hide = ref(false)
const props = defineProps(['btnTitle', 'title', 'form'])
const emits = defineEmits(['value', 'addOrEdit'])
const data = ref([])
const item = ref({})

const save = () => {
  emits('addOrEdit', data.value)
  hide.value = false
}


const show = (e) => {
  console.log(e, 'e');
  item.value = e
  hide.value = true
}

watch(hide, (value) => {
  if (value) {
    data.value = props.form

    data.value.forEach(e => {
      for (var f in item.value) {
        if (e.value === f) {
          e[e.value] = item.value[f]
        }
      }
    })
    console.log(item.value, 99);
  }
})
defineExpose({ show })

</script>
