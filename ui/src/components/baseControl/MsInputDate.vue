<template>
  <v-menu
    ref="menu"
    v-model="menu"
    :close-on-content-click="false"
    transition="scale-transition"
    offset-y
    min-width="auto"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-text-field
        v-model="dateFormatted"
        hint="MM/DD/YYYY format"
        persistent-hint
        append-icon="mdi-calendar"
        v-bind="attrs"
        @blur="date = parseDate(dateFormatted)"
        v-on="on"
        color="#2ca01c"
        outlined
        placeholder="Ngày cấp"
      ></v-text-field>
    </template>
    <v-date-picker
      v-model="date"
      no-title
      @input="menu = false"
      color="#2ca01c"
      locale="vi-CZ"
    ></v-date-picker>
  </v-menu>
</template>

<script>
export default {
  data: () => ({
    date: new Date().toISOString().substr(0, 10),
    dateFormatted: "",
    menu: false,
  }),
  computed: {
    computedDateFormatted() {
      return this.formatDate(this.date);
    },
  },
  watch: {
    date() {
      this.dateFormatted = this.formatDate(this.date);
    },
  },
  methods: {
    formatDate (date) {
      if (!date) return null

      const [year, month, day] = date.split('-')
      return `${day}/${month}/${year}`
    },
    parseDate (date) {
      if (!date) return null

      const [day, month,  year] = date.split('/')
      return `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`
    },
  },
};
</script>
