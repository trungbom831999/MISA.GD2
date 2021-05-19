<template>
  <div class="ms-input-date">
    <div v-if="label" class="flex">
      <div class="ms-input-title">
        <div class="ms-input-title-label">{{ label }}</div>
      </div>
      <div v-if="required" class="ms-input-title-require">&nbsp;*</div>
    </div>
    <!-- <div class="form-date">
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        transition="scale-transition"
        offset-y
        min-width="auto"
        left
        offset-overflow
      >
        <template v-slot:activator="{ on, attrs }">
          <input
            type="text"
            class="input-date"
            v-bind:value="value"
            v-on:input="$emit('input', dateFormatted)"
            :placeholder="placeholder"
            @blur="date = parseDate(dateFormatted)"
          />
          <span
            class="mi mi-30 mi-calendar icon-datepicker"
            v-bind="attrs"
            v-on="on"
          ></span>
        </template>
        <v-date-picker
          v-model="date"
          no-title
          @input="menu = false"
          next-icon="mdi-arrow-right"
          prev-icon="mdi-arrow-left"
          color="#2ca01c"
          locale="vi-CZ"
          style="max-height: 400px"
        ></v-date-picker>
      </v-menu>
    </div> -->

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
          ref="input"
          v-model="dateFormatted"
          v-bind:value="value"
          v-on:input="$emit('input', dateFormatted)"
          v-on:blur="$emit('input', dateFormatted)"
          v-on:focus="$emit('input', dateFormatted)"
          @
          hint="MM/DD/YYYY format"
          persistent-hint
          v-bind="attrs"
          @blur="date = parseDate(dateFormatted)"
          color="#2ca01c"
          outlined
          :placeholder="placeholder"
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
        next-icon="mdi-arrow-right"
        prev-icon="mdi-arrow-left"
        color="#2ca01c"
        locale="vi-CZ"
        style="max-height: 400px"
      ></v-date-picker>
    </v-menu>
  </div>
</template>

<script>
export default {
  props: {
    label: {
      type: String,
      default: "",
    },
    required: {
      type: Boolean,
      default: false,
    },
    placeholder: {
      type: String,
      default: "",
    },
    value: {},
  },
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
    menu(newV){
      if(!newV){
        this.focusInput();
      }
    }
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

    focusInput() {
      console.log(this.$refs.input);
      this.$refs.input.focus();
    },

    setDateDefault() {
      if (this.value) {
        this.dateFormatted = this.value;
        this.date = this.parseDate(this.dateFormatted);
      }
    },
  },
  mounted() {
    this.setDateDefault();
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

.ms-input-date .ms-input-title {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  white-space: nowrap;
}

.ms-input-date .ms-input-title-label {
  height: 100%;
}

.ms-input-date .ms-input-title-require {
  color: red;
  margin-left: 4px;
}

.ms-input-date .form-date {
  border: 1px solid #babec5;
  width: 100%;
  height: 32px;
  border-radius: 2px;
  box-sizing: border-box;
  display: flex;
  place-items: center;
}

.ms-input-date .input-date:not(:focus) .form-date:hover {
  outline: 1px solid #e2e2e2;
}

.ms-input-date .input-date {
  border-radius: 2px;
  flex: 1;
  min-height: 0;
  height: 100%;
  min-width: 0;
  background-color: #fff;
}

.ms-input-date .input-date:focus .form-date:not(.error) {
  border-color: #2ca01c;
}

.ms-input-date input {
  border: none;
  padding: 5px 10px;
  width: 100%;
  font-size: 13px;
  padding-right: 0;
}

.ms-input-date .icon-datepicker {
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
<style>
.ms-input-date .v-input__append-inner {
  margin: 0;
}

.ms-input-date .v-text-field--outlined {
  border-radius: 2px;
}

.ms-input-date .v-input__slot {
  background-color: #fff !important;
}

.ms-input-date .v-text-field .v-input__append-inner {
  padding: 2px;
}

.ms-input-date .v-text-field--outlined fieldset {
  top: -6.5px;
}

.v-date-picker-table thead {
  border-bottom: 1px solid #e0e0e0;
}
</style>