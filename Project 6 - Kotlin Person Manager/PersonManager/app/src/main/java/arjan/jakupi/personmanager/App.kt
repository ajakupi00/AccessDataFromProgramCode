package arjan.jakupi.personmanager

import android.app.Application
import arjan.jakupi.personmanager.dao.PeopleDatabase

import arjan.jakupi.personmanager.dao.PersonDao

class App : Application() {
    private lateinit var personDao: PersonDao
    fun getPersonDao() = personDao

    override fun onCreate() {
        super.onCreate()
        var db = PeopleDatabase.getInstance(this)
        personDao = db.personDao()
    }

}