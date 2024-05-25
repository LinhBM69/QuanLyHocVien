<template>
  <v-container class="fill-height justify-center">
    <form @submit.prevent="submit" class="w-75">
      <v-text-field v-model="name" label="Name" />

      <v-btn class="me-4" type="submit">
        submit
      </v-btn>

      <v-btn @click="handleReset">
        clear
      </v-btn>
    </form>
  </v-container>
</template>
