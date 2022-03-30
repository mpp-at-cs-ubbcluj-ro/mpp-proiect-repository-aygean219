package com.example.projectjava.InterfaceRepositories;


import com.example.projectjava.Domain.Entity;

public interface Repository<ID, E extends Entity<ID>> {
    /**
     * Gets all entities
     * @return iterable with all repo entities
     */
    Iterable<E> getAll();

    /**
     * Gets an entity
     * @param id the id of the searched entity
     * @return the searched entity
     * @throws Exception if entity not found in repo
     */
    E getOne(ID id) throws Exception;

    /**
     * Adds an entity to the repo
     * @param entity the entity to be added
     * @return the added entity
     * @throws Exception if entity already in repo
     */
    E add(E entity) throws Exception;

    /**
     * Removes an entity from the repo
     * @param id the id of the entity to be removed
     * @return the removed entity
     * @throws Exception if entity not found in repo
     */
    E remove(ID id) throws Exception;

    /**
     * Modifies one entity to another
     * @param id the id of the entity to be modified
     * @param newEntity the new entity that replaces the old one
     * @return the old entity
     * @throws Exception if the old entity is not found in the repo
     */
    E update(ID id, E newEntity) throws Exception;

    /**
     * Gets the repo as a string
     * @return a string with the entities of the repo
     */
    @Override
    String toString();
}