<template>
  <v-menu
    ref="menu"
    v-model="menu"
    :close-on-content-click="false"
    transition="scale-transition"
    offset-y
    min-width="auto"
    offset-overflow
  >
    <template v-slot:activator="{ on, attrs }">
      <v-text-field
        v-model="dateFormatted"
        hint="MM/DD/YYYY format"
        persistent-hint
        v-bind="attrs"
        @blur="date = parseDate(dateFormatted)"
        v-on="on"
        color="#2ca01c"
        outlined
        placeholder="Ngày cấp"
      >
        <template v-slot:append>
          <div v-on="on" style="display: flex; align-items: center">
            <span class="mi mi-24 mi-calendar icon-datepicker"></span>
          </div>
        </template>
      </v-text-field>
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
    formatDate(date) {
      if (!date) return null;

      const [year, month, day] = date.split("-");
      return `${day}/${month}/${year}`;
    },
    parseDate(date) {
      if (!date) return null;

      const [day, month, year] = date.split("/");
      return `${year}-${month.padStart(2, "0")}-${day.padStart(2, "0")}`;
    },
  },
};
</script>
<style scoped>
.ms-date-picker-container .icon-datepicker {
  background-color: #fff;
  cursor: pointer;
  display: block;
  width: 32px;
  font-size: 16px;
  color: #757575;
  background-position-x: -120px;
  height: 100%;
}
</style>